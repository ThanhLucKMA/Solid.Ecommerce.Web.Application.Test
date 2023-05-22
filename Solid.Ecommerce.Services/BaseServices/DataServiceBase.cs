
namespace Solid.Ecommerce.Services.BaseServices;
public abstract class DataServiceBase<TEntity>: IDataService<TEntity>
    where TEntity : class, new()
{
    protected  IUnitOfWork UnitOfWork { get; private set; }
    protected IMapper Mapper { get; private set; }

    public DataServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;

    }
    
    public abstract Task<IList<TEntity>> GetAllAsync();


    public abstract Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);


    public abstract Task<TEntity> GetOneAsync(int? id);


    public abstract Task UpdateAsync(TEntity entity);

    public abstract Task  AddAsync(TEntity entity);

    public abstract Task DeleteAsync(int productId);


    public abstract Task DeleteAysnc(TEntity entity);


    public TDestisnation Map<TSource, TDestisnation>(TSource source)
        where TSource : class
        where TDestisnation : class
    {
        return Mapper.Map<TSource, TDestisnation>(source);
    }
}
