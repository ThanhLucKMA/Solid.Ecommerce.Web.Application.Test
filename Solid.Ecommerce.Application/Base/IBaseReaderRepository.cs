


namespace Solid.Ecommerce.Application.Base;
public interface IBaseReaderRepository<T>: IBaseRepo<T> where T: class
{
    /// <summary>
    /// Get all items of an entity by asynchronous method
    /// </summary>
    /// <returns></returns>
    Task<IList<T>> GetAllAsync();

    /// <summary>
    /// Find one item of an entity synchronous method
    /// </summary>
    /// <param name="keyValues"></param>
    /// <returns></returns>
    T Find(params object[] keyValues);
    /// <summary>
    /// Find one item of an entity by asynchronous method 
    /// </summary>
    /// <param name="keyValues"></param>
    /// <returns></returns>
    Task<T> FindAsync(params object[] keyValues);
    /// <summary>
    /// Insert item into an entity by asynchronous method
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="saveChanges"></param>
    /// <returns></returns>
}
