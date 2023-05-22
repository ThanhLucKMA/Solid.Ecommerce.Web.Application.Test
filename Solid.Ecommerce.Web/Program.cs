using Solid.Ecommerce.Web;

Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseIISIntegration()
    .UseWebRoot("wwwroot")
    .UseStaticWebAssets()
    .UseStartup<Startup>();
    
    
})
.Build().Run();
Console.WriteLine("This executes after the web server has stopped!");
