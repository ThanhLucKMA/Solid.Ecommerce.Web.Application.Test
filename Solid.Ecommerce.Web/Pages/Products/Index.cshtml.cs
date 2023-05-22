using Solid.Ecommerce.Web.Utils;

namespace Solid.Ecommerce.Web.Pages.ProductByCategories;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    [ViewData]
    public string Title { get; set; }

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }
    public PaginatedList<Product> Products { get; set; }
    public int? SubCategoryId { get; set; }
    public async Task OnGetAsync(int? subCategoryId, int? pageIndex)
    {
        Title = subCategoryId.HasValue ? $"List product by {subCategoryId}" : $"List all products";
        SubCategoryId = subCategoryId.HasValue==false? null:subCategoryId;



        var products = SubCategoryId.HasValue ?
                (await _productService.GetAllAsync(p => p.ProductSubcategoryId == SubCategoryId)).AsQueryable() :
                (await _productService.GetAllAsync(p => p.ProductSubcategory.ProductCategoryId == 1)).AsQueryable();

        Products = PaginatedList<Product>.Create(products, pageIndex ?? 1);
      
    }
}
