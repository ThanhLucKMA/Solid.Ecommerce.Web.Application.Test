using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solid.Ecommerce.Application.Interfaces.Repositories;
using Solid.Ecommerce.Shared;
using Solid.Ecommerce.Application.Interfaces.Services;
using Solid.Ecommerce.Application.ViewModels.Products;
using Solid.Ecommerce.Infrastructure.Extensions;

namespace Solid.Ecommerce.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProductService _productService;
    public IList<Product> Products { get; private set; }

    public IndexModel(ILogger<IndexModel> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task  OnGetAsync()
    {
        /*
        Products = await _productService.GetAll();
        
       var productViewModel = Products[4];
       
        
        var p = _productService.MapViewModelTo(productViewModel);
        */

    }
   
}