namespace Solid.Ecommerce.Infrastructure.Repositories;
public class UnitOfWork: IUnitOfWork
{
    private Dictionary<string, object> Repositories { get; }
    private IDbContextTransaction _transaction;
    private IsolationLevel? _isolationLevel;

    public IApplicationDBContext ApplicationDBContext { get; private set; }

    public UnitOfWork(IApplicationDBContext applicationDBContext)
    {
        ApplicationDBContext = applicationDBContext;
        Repositories = new Dictionary<string, dynamic>();
    }
    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        var typeName = type.Name;

        lock (Repositories)
        {
            if (Repositories.ContainsKey(typeName))
            {
                return (IRepository<T>)Repositories[typeName];
            }

            var repository = new Repository<T>(ApplicationDBContext);

            Repositories.Add(typeName, repository);
            return repository;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await ApplicationDBContext.DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransaction()
    {
        await StartNewTransactionIfNeeded();
    }

    public async Task CommitTransaction()
    {
        /*
            do not open transaction here, because if during the request
            nothing was changed(only select queries were run), we don't
            want to open and commit an empty transaction -calling SaveChanges()
            on _transactionProvider will not send any sql to database in such case
           */
        await ApplicationDBContext.DbContext.SaveChangesAsync();

        if (_transaction == null) return;
        await _transaction.CommitAsync();

        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task RollbackTransaction()
    {
        if (_transaction == null) return;

        await _transaction.RollbackAsync();

        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public void Dispose()
    {
        if (ApplicationDBContext == null)
            return;
        //
        // Close connection
        if (ApplicationDBContext.DbContext.Database.GetDbConnection().State == ConnectionState.Open)
        {
            ApplicationDBContext.DbContext.Database.GetDbConnection().Close();
        }
        ApplicationDBContext.DbContext.Dispose();


        ApplicationDBContext = null;

        GC.SuppressFinalize(this);
    }
    /*
    ~UnitOfWork()
    {
        Dispose();
    }
    */
    private async Task StartNewTransactionIfNeeded()
    {
        if (_transaction == null)
        {
            _transaction = _isolationLevel.HasValue ?
                await ApplicationDBContext.DbContext.Database.BeginTransactionAsync(_isolationLevel.GetValueOrDefault()) : await ApplicationDBContext.DbContext.Database.BeginTransactionAsync();
        }
    }
}
