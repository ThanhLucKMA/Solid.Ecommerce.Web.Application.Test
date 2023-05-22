

using Solid.Ecommerce.Services.Services;

namespace Solid.Ecommerce.Web.Areas.Admin.Pages.Products;

public class CreateModel : BasePageModel<Product, CreateModel>
{
    private readonly IProductSubCategoryService _subCategoryService;
    private readonly IProductStatusService _productStatusService;
    [BindProperty]
    public ProductModel Product { get; set; }//để map với Product đưa vào edit
    public SelectList StatusSelectNameList { get; set; }
    public CreateModel(
        IProductService productService,
        IProductSubCategoryService subCategoryService,
        IProductStatusService productStatusService

        ) : base(productService, "Create")
    {
        _subCategoryService = subCategoryService;
        _productStatusService = productStatusService;

    }

    public async Task OnGetAsync()
    {
        await GetLookupValuesAsync(_subCategoryService, nameof(ProductCategory.ProductCategoryId),
          nameof(ProductCategory.Name));

        StatusSelectNameList = await GetLookupValuesByModelAsync(
            _productStatusService, 
            nameof(ProductStatus.StatusId),
            nameof(ProductStatus.StatusName));

    }

    public async Task<IActionResult> OnPostCreateNewProductAsync()
    {
        //Map nguoc lai vao Entity
        Entity = DataService.Map<ProductModel, Product>(Product);
        return await SaveOneAsync(DataService.AddAsync);
    }



}
