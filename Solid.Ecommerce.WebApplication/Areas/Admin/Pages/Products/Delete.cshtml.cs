using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solid.Ecommerce.Web.Areas.Admin.Pages.Products;

public class DeleteModel : BasePageModel<Product, DeleteModel>
{
    [BindProperty]
    public ProductViewModel Product { get; set; } = default!;
    public DeleteModel(
        IProductService productService) : base(productService, "Delete")
    {
    }


    public async Task OnGetAsync(int? id)
    {
        await GetOneAsync(id);
        Product = new ProductViewModel
        {
            ProductId = Entity.ProductId,
            ProductName = Entity.Name,
            ProductNumber = Entity.ProductNumber,
            Description = Entity.Description,
            PrimaryPhotoLargeFileName = Entity.ProductProductPhotos?
            .FirstOrDefault()?
            .ProductPhoto
            .LargePhotoFileName,
            ListPrice = Entity.ListPrice,
            StandardCost = Entity.StandardCost
        };
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        Id = id;
        return await DeleteOneAsync(id);
    }
}