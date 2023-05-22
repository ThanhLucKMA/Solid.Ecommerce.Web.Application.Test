
namespace Solid.Ecommerce.Services.Services;
public class ProductSubCategoryService : DataServiceBase<ProductSubcategory>, IProductSubCategoryService
{
    public ProductSubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        :base(unitOfWork, mapper)
    {
        
    }

    public override Task<int?> AddAsync(ProductSubcategory entity)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAysnc(ProductSubcategory entity)
    {
        throw new NotImplementedException();
    }

    public override async Task<IList<ProductSubcategory>> GetAllAsync()
    => await UnitOfWork.Repository<ProductSubcategory>()
        .Entities
        .ToListAsync();

    public override async Task<IEnumerable<ProductSubcategory>> GetAllAsync(Expression<Func<ProductSubcategory, bool>> predicate)
      => await UnitOfWork.Repository<ProductSubcategory>()
        .Entities
        .Where(predicate)
        .ToListAsync();


    public override Task<ProductSubcategory> GetOneAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateAsync(ProductSubcategory entity)
    {
        throw new NotImplementedException();
    }
}
