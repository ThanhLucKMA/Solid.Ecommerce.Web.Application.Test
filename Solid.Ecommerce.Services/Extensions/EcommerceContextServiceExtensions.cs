

using Solid.Ecommerce.Application.Interfaces.Services;

namespace Solid.Ecommerce.Services.Extensions;
public static class EcommerceContextServiceExtensions
{
    public static IServiceCollection EcommerceInfrastructureDatabase(
        this IServiceCollection services, IConfiguration config)
    {
        
        services.AddDbContext<SolidEcommerceDbContext>(options =>
            {
               
                options.UseSqlServer(config.GetConnectionString("SolidEcomerceDB"),
                sqlOptions => sqlOptions.CommandTimeout(120));
                options.UseLazyLoadingProxies();//must be install package Microsoft.EntityFrameworkCore.Proxies

            });
        
        services.AddScoped<Func<SolidEcommerceDbContext>>(
            (provider) => () => provider.GetService<SolidEcommerceDbContext>()
            );
        services.AddScoped<DbFactoryContext>();
        
        services.AddScoped<IApplicationDBContext, ApplicationDbContext>();
       
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
       
        return services;
    }
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductSubCategoryService, ProductSubCategoryService>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<IProductStatusService, ProductStatusService>();
        services.AddScoped<IPersonService, PersonService>();

        return services;
    }

    public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
    {
         IMapper _mapper;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = config.CreateMapper();

        services.AddSingleton(_mapper);

      

        return services;
    }
    
}
