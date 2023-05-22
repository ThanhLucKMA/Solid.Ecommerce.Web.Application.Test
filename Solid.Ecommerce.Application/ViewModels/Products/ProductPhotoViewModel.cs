namespace Solid.Ecommerce.Application.ViewModels.Products;
public class ProductPhotoViewModel:IMapFrom<ProductPhoto>
{
    public int ProductPhotoId { get; set; }
    public string? ThumbnailPhotoFileName { get; set; }
    public string? LargePhotoFileName { get; set; }
    /*A collection of ProductProductPhoto*/
    public  ICollection<ProductProductPhotoViewModel> ProductProductPhotos { get; } = new List<ProductProductPhotoViewModel>();
}
