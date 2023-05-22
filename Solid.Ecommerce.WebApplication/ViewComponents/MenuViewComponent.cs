
namespace Solid.Ecommerce.Web.ViewComponents;
//https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components
//The runtime searches for the view in the following paths:
//    Views/<controller_name>/Components/<view_component_name>/<view_name>
//    Views/Shared/Components/<view_component_name>/<view_name>
//    /Pages/Shared/Components/<View Component Name>/<View Name>

public class MenuViewComponent: ViewComponent
{
    private readonly IProductSubCategoryService _productCategoryService;

    public MenuViewComponent(IProductSubCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var productSubCategories = (await _productCategoryService.GetAllAsync(psc=>psc.ProductCategoryId==1))
            .ToList();
        if (!productSubCategories.Any())
        {
            return new ContentViewComponentResult("Unable to get the makes");
        }
        return View("MenuView", productSubCategories);

    }

}
