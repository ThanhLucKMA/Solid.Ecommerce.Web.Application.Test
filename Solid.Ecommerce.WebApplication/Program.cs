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
using Microsoft.AspNetCore.Identity.UI.Services;
using Test_send_mail.Helper;

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


        /*builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContextIdentity>()
        .AddDefaultTokenProviders();*/

        //Set session cookie flag
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);//Thoi gian gioi han session
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });

        //Set HSTS
        builder.Services.AddHsts(options =>
        {
            options.IncludeSubDomains = true;
            options.MaxAge = TimeSpan.FromDays(365);
        });

        //Set Anti CSRF
        builder.Services.AddAntiforgery(options =>
        {
            options.FormFieldName = "_AntiCSRFToken";//Chong gia mao (1)
            options.HeaderName = "X-Anti-Xsrf-Token";//(2)
        });


        //Set options password to control user
        builder.Services.AddDefaultIdentity<IdentityUser>(options => {

            options.SignIn.RequireConfirmedAccount = true;

            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 6;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;

            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.AllowedForNewUsers = true;
        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContextIdentity>();


        //Configure cookie 
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "AuthenticationCookieLucBT";
            options.Cookie.HttpOnly = true;					
	        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
	        options.Cookie.SameSite = SameSiteMode.Strict;		
	        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);	
	        options.SlidingExpiration = true;
        });

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

        
        builder.Services.AddTransient<ISendMailService, SendMail>();
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("SuperUser", policy =>
                policy.RequireRole("Administrator","Editer"));            
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();

            app.UseRouting();
            app.UseHttpsRedirection();
            //app.UseDefaultFiles();
            app.UseResponseCompression();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

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

        app.Run();
    }
}