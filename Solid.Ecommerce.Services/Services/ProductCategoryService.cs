namespace Solid.Ecommerce.Services.Services;
public class ProductCategoryService : DataServiceBase<ProductCategory>, IProductCategoryService
{
    public ProductCategoryService(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper)
    {


    }
    public override Task<int?> AddAsync(ProductCategory entity)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAysnc(ProductCategory entity)
    {
        throw new NotImplementedException();
    }

    public override async Task<IList<ProductCategory>> GetAllAsync()
     => await UnitOfWork.Repository<ProductCategory>()
        .Entities
        .ToListAsync();

    public override async Task<IEnumerable<ProductCategory>> GetAllAsync(Expression<Func<ProductCategory, bool>> predicate)
    => await UnitOfWork.Repository<ProductCategory>()
        .Entities
        .Where(predicate)
        .ToListAsync();

    public override Task<ProductCategory> GetOneAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateAsync(ProductCategory entity)
    {
        throw new NotImplementedException();
    }
}
