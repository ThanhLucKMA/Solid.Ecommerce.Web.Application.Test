
namespace Solid.Ecommerce.Web.ViewComponents;
[ViewComponent]
public class ProductCard : ViewComponent
{
    private Product _product;
    public ProductCard() { }

    public IViewComponentResult Invoke(Product product)
    {
        _product = product;
        return View(_product);
    }
}
