using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
namespace Solid.Ecommerce.Application.ViewModels.Products;
public class ProductViewModel:IMapFrom<Product>
{
    public ProductViewModel()
    {
        ProductProductPhotos  = new List<ProductProductPhotoViewModel>();
    }
    
    public int ProductId { get; set; }
    [Display(Name ="Product Name")]
    public string ProductName { get; set; } = null!;
    [Display(Name = "Number")]
    public string ProductNumber { get; set; } = null!;
    public bool? MakeFlag { get; set; }
    public string? Color { get; set; }
    [Display(Name = "Cost")]
    public decimal StandardCost { get; set; }
    [Display(Name = "Price")]
    public decimal ListPrice { get; set; }

    public string? ProductLine { get; set; }
    public int ProductCategoryId { get; set; }
    [Display(Name = "Desc")]
    public string? Description { get; set; }
    public int? StatusId { get; set; }
    public virtual ProductStatusViewModel? Status { get; set; }
    public string? PrimaryPhotoLargeFileName { get; set; }
    [Display(Name = "Percent")]
    public decimal? DiscountPercent { get; set; }
    public  virtual ICollection<ProductProductPhotoViewModel> ProductProductPhotos { get; set; }
    public virtual  ProductSubcategoryViewModel? ProductSubcategory { get; set; }

    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductViewModel>()
        .ForMember(dst => dst.ProductName,
        src => src.MapFrom(p => p.Name));

        profile.CreateMap<ProductViewModel, Product>()
             .ForMember(dst => dst.Name,
        src => src.MapFrom(p => p.ProductName));

    }
}
