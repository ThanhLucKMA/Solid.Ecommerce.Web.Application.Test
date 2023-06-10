using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solid.Ecommerce.WebApplication.Data;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Solid.Ecommerce.WebApplication.Areas.Admin.Pages.Role;
[Authorize(Roles = "Administrator")]
public class CreateModel : RolePageModel
{
    public CreateModel(RoleManager<IdentityRole> roleManager, ApplicationDbContextIdentity dbContextIdentity) : base(roleManager, dbContextIdentity)
    {
    }

    public class InputModel
    {

        [Display(Name = "Name-Role")]
        [Required(ErrorMessage ="Must Enter {0}")]
        [StringLength(256, MinimumLength =3,ErrorMessage ="{0} Must from {2} to {1} characters")]
        public string Name { get; set; }
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var newRole = new IdentityRole(Input.Name);
        var result = await _roleManager.CreateAsync(newRole);
        if (result.Succeeded)
        {
            StatusMessage = $"You just create new role {Input.Name}";
            return RedirectToPage("./Index");
        }
        else
        {
            result.Errors.ToList().ForEach(error =>
            {
                ModelState.AddModelError(string.Empty, error.Description);
            });
        } 
        
        return Page();
    }
}
