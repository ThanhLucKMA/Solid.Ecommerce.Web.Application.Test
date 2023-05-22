

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Solid.Ecommerce.Application.ViewModels.Products;

public class ProductStatusViewModel: IMapFrom<ProductStatus>
{
    public int StatusId { get; set; }
    [Display(Name = "Status")]
    public string? StatusName { get; set; }

}
