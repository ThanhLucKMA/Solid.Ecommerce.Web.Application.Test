using System.ComponentModel.DataAnnotations;

namespace Solid.Ecommerce.Application.ViewModels.Products;
public class ProductSubcategoryViewModel:IMapFrom<ProductSubcategory>
{
    public int ProductSubcategoryId { get; set; }
    public int ProductCategoryId { get; set; }
    [Display(Name="Subcategory Name")]
    public string Name { get; set; } = null;

    public  ProductCategoryViewModel ProductCategory { get; set; } = null!;
    public  ICollection<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

}
