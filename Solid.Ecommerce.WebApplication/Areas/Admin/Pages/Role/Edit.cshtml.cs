using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solid.Ecommerce.WebApplication.Data;
using System.ComponentModel.DataAnnotations;

namespace Solid.Ecommerce.WebApplication.Areas.Admin.Pages.Role;

public class EditModel : RolePageModel
{
    public EditModel(RoleManager<IdentityRole> roleManager, ApplicationDbContextIdentity dbContextIdentity) : base(roleManager, dbContextIdentity)
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

    public IdentityRole role { get; set; }
   
    public async Task<IActionResult> OnGet(string roleid)
    {
        if(roleid is null)
        {
            return NotFound("Không tìm thấy Role");
        }
        role = await _roleManager.FindByIdAsync(roleid);
        if(role != null)
        {
            Input = new InputModel
            {
                Name = role.Name,
            };
            return Page();
        }
        return NotFound("Không tìm thấy Role");
    }

    public async Task<IActionResult> OnPostAsync(string roleid)
    {
        if (roleid is null) return NotFound("Không tìm thấy Role");
        role = await _roleManager.FindByIdAsync(roleid);
        if (role is null ) return NotFound("Không tìm thấy Role");
        if (!ModelState.IsValid)
        {
            return Page();
        }
        role.Name = Input.Name;
        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            StatusMessage = $"You just change name: {Input.Name}";
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
