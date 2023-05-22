namespace Solid.Ecommerce.Infrastructure.Context;
public class ApplicationDbContext: IApplicationDBContext
{
    private DbFactoryContext _dbFactoryContext;
    public ApplicationDbContext(DbFactoryContext dbFactoryContext) 
        => this._dbFactoryContext = dbFactoryContext;
    public DbContext DbContext => _dbFactoryContext.DbContext;
}
