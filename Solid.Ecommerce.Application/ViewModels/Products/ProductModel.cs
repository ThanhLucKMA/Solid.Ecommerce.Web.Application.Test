

using System.ComponentModel.DataAnnotations;

namespace Solid.Ecommerce.Application.ViewModels.Products;

public class ProductModel:IMapFrom<Product>
{
    public int ProductId { get; set; }
    [Display(Name = "Product Name")]
    public string Name { get; set; } = null!;
    [Display(Name = "Number")]
    public string ProductNumber { get; set; } = null!;
    public bool? MakeFlag { get; set; }
    [Required(ErrorMessage = "The Color name is required")]
    public string? Color { get; set; }
    [Display(Name = "Cost")]
    public decimal StandardCost { get; set; }
    [Display(Name = "Price")]
    public decimal ListPrice { get; set; }

    public string? ProductLine { get; set; }
    [Display(Name="Subcategory Name")]
    public int? ProductSubcategoryId { get; set; }
    [Display(Name = "Desc")]
    public string? Description { get; set; }
    [Display(Name = "Status")]
    public int? StatusId { get; set; }
    public string? PrimaryPhotoLargeFileName { get; set; }
    [Display(Name = "Discount")]
    public decimal? DiscountPercent { get; set; }
    [Display(Name = "Start Date Sell")]
    public DateTime SellStartDate { get; set; }
    [Display(Name = "End Date Sell")]
    public DateTime? SellEndDate { get; set; }
    [Display(Name = "Discontinued Date")]
    public DateTime? DiscontinuedDate { get; set; }

}
