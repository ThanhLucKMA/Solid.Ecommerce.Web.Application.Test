namespace Solid.Ecommerce.Application.ViewModels.Products;
public class ProductProductPhotoViewModel:IMapFrom<ProductProductPhoto>
{
    public int ProductId { get; set; }
    public int ProductPhotoId { get; set; }
    public bool Primary { get; set; }
    public  ProductViewModel Product { get; set; } = null!;
    public  ProductPhotoViewModel ProductPhoto { get; set; } = null!;
}
