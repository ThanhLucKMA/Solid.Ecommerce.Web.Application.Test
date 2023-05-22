
namespace Solid.Ecommerce.Infrastructure.Context;
public class DbFactoryContext:IDisposable
{
    private bool _disposed;
    private Func<SolidEcommerceDbContext> _instanceFunc;
    private DbContext _dbContext;
    public DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());
    public DbFactoryContext(Func<SolidEcommerceDbContext> dbContextFactory)
    {
        _instanceFunc = dbContextFactory;
    }
    
    public void Dispose()
    {
        if (!_disposed && _dbContext != null)
        {
            _disposed = true;
            _dbContext.Dispose();
        }
    }
   
}
