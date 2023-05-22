

using Solid.Ecommerce.Shared;

namespace Solid.Ecommerce.Services.Services;

public class PersonService: DataServiceBase<Person>, IPersonService
{
    public PersonService(IUnitOfWork unitOfWork, IMapper mapper) : base(
        unitOfWork, mapper)
    {

    }

    public override Task AddAsync(Person entity)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAysnc(Person entity)
    {
        throw new NotImplementedException();
    }

    public async override Task<IList<Person>> GetAllAsync()
    => await UnitOfWork.Repository<Person>()
        .Entities
        .ToListAsync();


    public override Task<IEnumerable<Person>> GetAllAsync(Expression<Func<Person, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public override async Task<Person> GetOneAsync(int? id)
    {
       return await UnitOfWork.Repository<Person>()
           .Entities
           .FindAsync(id);
       
    }

    public override Task UpdateAsync(Person entity)
    {
        throw new NotImplementedException();
    }
}
