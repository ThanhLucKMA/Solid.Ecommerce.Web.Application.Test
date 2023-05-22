using System.ComponentModel.DataAnnotations;

namespace Solid.Ecommerce.Application.ViewModels.Products;
public class ProductCategoryViewModel:IMapFrom<ProductCategory>
{
    public int ProductCategoryId { get; set; }
    [Display(Name="Category Name")]
    public string Name { get; set; } = null!;
    public ICollection<ProductSubcategoryViewModel> ProductSubcategories { get; } = new List<ProductSubcategoryViewModel>();


}
