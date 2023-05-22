using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Solid.Ecommerce.Shared;


namespace Solid.Ecommerce.Web.Areas.Admin.Pages.ProductsAsync;

public class IndexModel : PageModel
{
    private readonly IRazorRenderService _renderService;
    private readonly IProductService _productService;
    private readonly IProductStatusService _productStatusService;
    private readonly IProductSubCategoryService _productSubCategoryService;

    public IEnumerable<Product> Products { get; set; }
    public ProductModel Product { get; set; } 
   
    public SelectList StatusSelectNameList { get; set; }
    public SelectList SubcategorySelectNameList { get; set; }
    public IndexModel(IProductService productService, IProductStatusService productStatusService,
        IRazorRenderService renderService,IProductSubCategoryService productSubCategoryService)
    {
        _renderService = renderService;
        _productService = productService;
        _productStatusService = productStatusService;
        _productSubCategoryService= productSubCategoryService;
        Product = new();
    }


    public async Task<PartialViewResult> OnGetViewAllPartial()
    {

        Products = await _productService.GetAllAsync();

        return new PartialViewResult
        {
            ViewName = "Partials/_ViewAllProduct",
            ViewData = new ViewDataDictionary<IEnumerable<Product>>(ViewData, Products)
        };
    }
    public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
    {
        StatusSelectNameList = await GetLookupValuesByModelAsync(
          _productStatusService, nameof(ProductStatus.StatusId), nameof(ProductStatus.StatusName));

        SubcategorySelectNameList = await GetLookupValuesByModelAsync(
       _productSubCategoryService, nameof(ProductSubcategory.ProductSubcategoryId), nameof(ProductSubcategory.Name));
        
        if (id == 0)

            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("Partials/_CreateOrEdit", this) });
        else
        {
            var product = await _productService.GetOneAsync(id);

            Product = _productService.Map<Product, ProductModel>(product);

           
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("Partials/_CreateOrEdit", this) });
        }
    }
    public async Task<JsonResult> OnPostCreateOrEditAsync(int id, ProductModel product)
    { 
        var p = _productService.Map<ProductModel, Product>(product);
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                await _productService.AddAsync(p);

            }
            else
            {
                await _productService.UpdateAsync(p);

            }
            Products = await _productService.GetAllAsync();
            var html = await _renderService.ToStringAsync("Partials/_ViewAllProduct", Products);
            return new JsonResult(new { isValid = true, html = html });
        }
        else
        {
            var html = await _renderService.ToStringAsync("Partials/_CreateOrEdit", Products);
            return new JsonResult(new { isValid = false, html = html });
        }
    }

    public async Task<JsonResult> OnPostDeleteAsync(int id)
    {
      
        await _productService.DeleteAsync(id);
        
        Products = await _productService.GetAllAsync();
        var html = await _renderService.ToStringAsync("Partials/_ViewAll", Products);
        return new JsonResult(new { isValid = true, html = html });
    }

    private async Task<SelectList> GetLookupValuesByModelAsync<TLookupEntity>(
     IDataService<TLookupEntity> lookupService, string lookupKey, string lookupDisplay)
     where TLookupEntity : class, new()
    {
        return new(await lookupService.GetAllAsync(), lookupKey, lookupDisplay);
    }

    
}
