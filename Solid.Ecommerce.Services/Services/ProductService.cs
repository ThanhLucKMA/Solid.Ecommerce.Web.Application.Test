
namespace Solid.Ecommerce.Services.Services;
public class ProductService : DataServiceBase<Product>, IProductService
{
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper):base(
        unitOfWork,mapper)
    {

    }
    public override async Task AddAsync(Product entity)
    {
        try
        {
            await UnitOfWork.BeginTransaction();
            await UnitOfWork.Repository<Product>()
                .InsertAsync(entity);
            
            await UnitOfWork.CommitTransaction();
            
            
        }
        catch (Exception ex)
        {
            await UnitOfWork.RollbackTransaction();
            throw;
        }
    }
    

    public override async Task DeleteAsync(int id)
    {
        try
        {
            await UnitOfWork.BeginTransaction();

            var productRepos = UnitOfWork.Repository<Product>();
            var pro = await productRepos.FindAsync(id);
            if (pro == null)
                throw new KeyNotFoundException();

            await productRepos.DeleteAsync(pro);

            await UnitOfWork.CommitTransaction();
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransaction();
            throw;
        }
    }

    public override async Task<Product> GetOneAsync(int? id)
    {
        var product = await UnitOfWork.Repository<Product>()
            .Entities
            .FindAsync(id);
        return product;
    }

  

    public override async Task<IList<Product>> GetAllAsync()
    => await UnitOfWork.Repository<Product>()
        .Entities
        .Include(p=>p.ProductSubcategory)
        .Where(p=> p.ProductSubcategoryId != null)
        .ToListAsync();


    public override async Task UpdateAsync(Product entity)
    {
        try
        {
           

            await UnitOfWork.BeginTransaction();
            var productRepos = UnitOfWork.Repository<Product>();
            var pro = await productRepos.FindAsync(entity.ProductId);
            if (pro == null)
                throw new KeyNotFoundException();

            pro.Name = entity.Name;
            pro.Color = entity.Color;
            pro.ProductSubcategoryId= entity.ProductSubcategoryId; 
            pro.StatusId=entity.StatusId;

            await UnitOfWork.CommitTransaction();
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransaction();
            throw;
        }
    }


    public override async Task DeleteAysnc(Product entity)
    {
        try
        {

            await UnitOfWork.BeginTransaction();
 
            await UnitOfWork.Repository<Product>().DeleteAsync(entity);

            await UnitOfWork.CommitTransaction();
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransaction();
            throw;
        }
    }

    public override  async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> predicate)
    => await UnitOfWork.Repository<Product>()
        .Entities
        .Include(p => p.ProductProductPhotos)
        .ThenInclude(ppp => ppp.ProductPhoto)
        .Where(predicate)
        .ToListAsync();    


}
