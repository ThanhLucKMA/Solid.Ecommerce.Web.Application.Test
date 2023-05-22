namespace Solid.Ecommerce.Infrastructure.Extensions;
public static class ProductRepositoryExtension
{
    /// <summary>
    /// Get all items of work table from stored procedure
    /// </summary>
    /// <param name="repository"></param>
    /// <returns></returns>
    public static async Task<IList<Product>> GetAll(this IRepository<Product> repository)
    {
        var products = new List<Product>();
        
        await repository.ApplicationDBContext.DbContext.LoadStoredProc("spGetWorks")
            //.WithSqlParam("sampleParam", "sampleValue") // Sample code to add params to provided stored procedure
            .ExecuteStoredProcAsync(result =>
            {
                // Read value to list
                products = result.ReadNextListOrEmpty<Product>();
                // Sample code to read to value
                // var getOne = result.ReadToValue<int>() 
            });


        return products;
    }
}
