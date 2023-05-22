namespace Solid.Ecommerce.Services.Services;
public class ProductStatusService : DataServiceBase<ProductStatus>, IProductStatusService
{
    public ProductStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        :base(unitOfWork, mapper)
    {
      

    }

    public override Task<int?> AddAsync(ProductStatus entity)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAysnc(ProductStatus entity)
    {
        throw new NotImplementedException();
    }

    public override async Task<IList<ProductStatus>> GetAllAsync()
     => await UnitOfWork.Repository<ProductStatus>()
        .Entities
        .ToListAsync();
    public override async Task<IEnumerable<ProductStatus>> GetAllAsync(Expression<Func<ProductStatus, bool>> predicate)
        => await UnitOfWork.Repository<ProductStatus>()
        .Entities
        .Where(predicate)
        .ToListAsync();

    public override Task<ProductStatus> GetOneAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateAsync(ProductStatus entity)
    {
        throw new NotImplementedException();
    }
}
