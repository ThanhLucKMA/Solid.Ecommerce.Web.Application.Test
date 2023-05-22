namespace Solid.Ecommerce.Application.Interfaces.Services;
public interface IDataService<TEntity>  where TEntity : class, new()
{
    Task<IList<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
   
    Task<TEntity> GetOneAsync(int? id);
    Task UpdateAsync(TEntity entity);
    Task AddAsync(TEntity entity);
    Task DeleteAsync(int productId);
    Task DeleteAysnc(TEntity entity);

    TDestisnation Map<TSource, TDestisnation>(TSource source) where TSource : class 
                                                              where TDestisnation : class;
}

