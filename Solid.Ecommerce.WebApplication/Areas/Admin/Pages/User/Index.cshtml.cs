using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;
using Solid.Ecommerce.WebApplication.Data;
using Solid.Ecommerce.WebApplication.Models;

namespace Solid.Ecommerce.WebApplication.Areas.Admin.Pages.User;

public class IndexModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    public IndexModel(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [TempData]
    public string StatusMassage { get; set; }
     public string RoleName { get; set; }
    
    public List<IdentityUser> users { get; set; }

    public int totalUser { get; set; }

    public async Task OnGet()
    {
        totalUser = await _userManager.Users.OrderBy(u => u.UserName).CountAsync();
        users = await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();
    }

    public void OnPost() => RedirectToPage();

}
