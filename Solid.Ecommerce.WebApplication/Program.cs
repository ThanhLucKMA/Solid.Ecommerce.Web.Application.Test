using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Solid.Ecommerce.Application.Interfaces.Services;
using Solid.Ecommerce.Services.Services;
using Solid.Ecommerce.WebApplication.Data;
using Solid.Ecommerce.Services.Extensions;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Solid.Ecommerce.Infrastructure.Context;
using Solid.Ecommerce.Application.Interfaces.Common;

public class Program
{
    //public IConfiguration Configuration { get; }
    

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionStringIdentity = builder.Configuration.GetConnectionString("SolidEcommerceWebApplicationContextConnection");

        var connectionStringDBContext = builder.Configuration.GetConnectionString("SolidEcomerceDB");

        builder.Services.AddDbContext<ApplicationDbContextIdentity>(options =>
            options.UseSqlServer(connectionStringIdentity));


        builder.Services.AddDbContext<SolidEcommerceDbContext>(options =>
            options.UseSqlServer(connectionStringDBContext));


        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                 .AddEntityFrameworkStores<ApplicationDbContextIdentity>();

        builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        builder.Services.AddScoped<IRazorRenderService, RazorRenderService>();
        builder.Services.AddResponseCompression(options =>
        {
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "text/javascript" }
            );
        });

        //builder.Services.AddRazorPages();
        builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
        {
           //options.Conventions.AddPageRoute("/Products/Index", "/");
           //options.Conventions.AddAreaPageRoute("Admin", "/Products/Index", "/");
        }
    );

        builder.Services.EcommerceInfrastructureDatabase(builder.Configuration);
        builder.Services.AddDataServices();
        builder.Services.AddAutoMapperService();

     


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();

            app.UseRouting();
            app.UseHttpsRedirection();
            //app.UseDefaultFiles();
            app.UseResponseCompression();

            
            app.UseStaticFiles();


           // app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                
                endpoints.MapGet("/hello", () => "Hello World!");
               // endpoints.MapGet("/", () => "/Products/Index");
                // endpoints.MapGet("/", ctx => ctx.Request.Path == "/" ? "/Index" : ctx.Request.Path);
            });
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        //app.UseWebOptimizer();

        

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}