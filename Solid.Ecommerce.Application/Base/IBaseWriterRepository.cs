namespace Solid.Ecommerce.Application.Base;

public interface IBaseWriterRepository<T>:IBaseRepo<T> where T: class
{
    /// <summary>
    /// Insert item into an entity by asynchronous method
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="saveChanges"></param>
    /// <returns></returns>
    Task InsertAsync(T entity, bool saveChanges = true);
    /// <summary>
    /// Insert multiple items into an entity by asynchronous method
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="saveChanges"></param>
    /// <returns></returns>
    Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true);
    /// <summary>
    /// Update one item from an entity by asynchronous method
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="saveChanges"></param>
    /// <returns></returns>
    /// 
    Task UpdateAsync(T entity, bool saveChanges = true);
    /// <summary>
    /// Update multiple items into an entity by asynchronous method
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="saveChanges"></param>
    /// <returns></returns>
    Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = true);
    /// <summary>
    /// Remove one item from an entity by asynchronous method
    /// </summary>
    /// <param name="id"></param>
    /// <param name="saveChanges"></param>
    /// <returns></returns>
    Task DeleteAsync(int id, bool saveChanges = true);
    /// <summary>
    /// Remove one item from an entity by asynchronous method
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="saveChanges"></param>
    /// <returns></returns>
    Task DeleteAsync(T entity, bool saveChanges = true);
    /// <summary>
    /// Remove multiple items from an entity by asynchronous method
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="saveChanges"></param>
    /// <returns></returns>
    Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true);
}
