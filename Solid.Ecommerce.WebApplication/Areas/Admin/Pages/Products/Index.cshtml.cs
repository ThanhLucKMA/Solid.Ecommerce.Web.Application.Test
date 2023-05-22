using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solid.Ecommerce.Web.Areas.Admin.Pages.Products;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    private readonly IProductSubCategoryService _productSubCategoryService;

    public IndexModel(IProductService productService, IProductSubCategoryService productSubCategoryService)
    {
        _productService = productService;
        _productSubCategoryService = productSubCategoryService;
    }
    [ViewData]
    public string Title { get; set; }    

    public IEnumerable<Product> ProductRecords { get; set; }
    public async Task OnGetAsync()
    {
        Title = "Inventory";
        ProductRecords = await _productService.GetAllAsync();
    }
}
