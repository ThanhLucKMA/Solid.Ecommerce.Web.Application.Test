using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solid.Ecommerce.WebApplication.Data;
using System.ComponentModel.DataAnnotations;

namespace Solid.Ecommerce.WebApplication.Areas.Admin.Pages.Role;
[Authorize(Roles = "Administrator")]
public class DeleteModel : RolePageModel
{
    public DeleteModel(RoleManager<IdentityRole> roleManager, ApplicationDbContextIdentity dbContextIdentity) : base(roleManager, dbContextIdentity)
    {
    }

    public IdentityRole role { get; set; }
   
    public async Task<IActionResult> OnGet(string roleid)
    {

        if (roleid == null) return NotFound("Không tìm thấy Role");
        role = await _roleManager.FindByIdAsync(roleid);
       
        if(role == null) return NotFound("Không tìm thấy...");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string roleid)
    {
        if (roleid == null) return NotFound("Không tìm thấy Role...");
        role = await _roleManager.FindByIdAsync(roleid);
        if (role == null ) return NotFound("Không tìm thấy Role..");
        
        var result = await _roleManager.DeleteAsync(role);

        if (result.Succeeded)
        {
            StatusMessage = $"You just delete role: {role.Name}";
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
