using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;
using Solid.Ecommerce.WebApplication.Data;

namespace Solid.Ecommerce.WebApplication.Areas.Admin.Pages.Role;

public class IndexModel : RolePageModel
{
    public IndexModel(RoleManager<IdentityRole> roleManager, ApplicationDbContextIdentity dbContextIdentity) : base(roleManager, dbContextIdentity)
    {
    }

    public List<IdentityRole> roles { get; set; }

    public async Task OnGet()
    {
        roles = await _roleManager.Roles.OrderBy(r => r.Name).ToListAsync();
    }

    public void OnPost() => RedirectToPage();

}
