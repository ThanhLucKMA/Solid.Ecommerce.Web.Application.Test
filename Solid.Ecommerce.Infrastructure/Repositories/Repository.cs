using Solid.Ecommerce.Application.Interfaces.Repositories;

namespace Solid.Ecommerce.Infrastructure.Repositories;
public class Repository<T>:IRepository<T> where T: class
{
  
    public IApplicationDBContext ApplicationDBContext { get; private set; }

    public DbSet<T> Entities => ApplicationDBContext.DbContext.Set<T>();    
    /*Constructor*/
    public Repository(IApplicationDBContext applicationDBContext)
        => ApplicationDBContext = applicationDBContext;

    public async Task<IList<T>> GetAllAsync() => await Entities.ToListAsync<T>();


    public T Find(params object[] keyValues) => Entities.Find(keyValues);


    public virtual async  Task<T> FindAsync(params object[] keyValues) 
        => await Entities.FindAsync(keyValues);


    public async Task InsertAsync(T entity, bool saveChanges = true)
    {
        
        await Entities.AddAsync(entity);
        if (saveChanges)
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }

    public async Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        await ApplicationDBContext.DbContext.AddRangeAsync(entities);

        if (saveChanges)

        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(T entity, bool saveChanges = true)
    {
        Entities.Update(entity);    
        if (saveChanges)
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        Entities.UpdateRange(entities); 
        
    }

    public async Task DeleteAsync(int id, bool saveChanges = true)
    {
        var entity = await Entities.FindAsync(id);
        await DeleteAsync(entity);

        if (saveChanges)

        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
       
    }

    public async Task DeleteAsync(T entity, bool saveChanges = true)
    {
        Entities.Remove(entity);
        if (saveChanges)
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        var enumerable = entities as T[] ?? entities.ToArray();
        if (enumerable.Any())
        {
            Entities.RemoveRange(enumerable);
        }

        if (saveChanges)
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }
}
