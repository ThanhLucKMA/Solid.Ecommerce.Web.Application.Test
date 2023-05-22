namespace Solid.Ecommerce.Web.Areas.Admin.Pages.Products;
public class EditModel : BasePageModel<Product, EditModel>
{
    private readonly IProductSubCategoryService _subCategoryService;
    private readonly IProductStatusService _productStatusService;
    [BindProperty]
    public ProductModel Product { get; set; }//để map với Product đưa vào edit
    public SelectList StatusSelectNameList { get; set; }    
    public EditModel(
        IProductService productService,
        IProductSubCategoryService subCategoryService, IProductStatusService productStatusService)
        : base(productService, "Edit")
    {
        _subCategoryService = subCategoryService;
        _productStatusService = productStatusService;


    }
    public async Task OnGetAsync(int? id)
    {
        await GetLookupValuesAsync(_subCategoryService, nameof(ProductCategory.ProductCategoryId),
           nameof(ProductCategory.Name));

        await GetOneAsync(id);

        // Product = DataService.MapToModel<ProductModel>(Entity);
        Product = DataService.Map<Product, ProductModel>(Entity);

        StatusSelectNameList =await GetLookupValuesByModelAsync(
            _productStatusService, nameof(ProductStatus.StatusId),
           nameof(ProductStatus.StatusName));
    }
    public async Task<IActionResult> OnPostAsync(int? id)
    {
        //Map nguoc lai vao Entity
        Entity = DataService.Map<ProductModel,Product>(Product);
        Id = id;
        return await SaveWithLookupAsync(
            DataService.UpdateAsync,
            _subCategoryService,
            
            nameof(ProductSubcategory.ProductSubcategoryId),
            nameof(ProductSubcategory.Name));

    }

   
}
