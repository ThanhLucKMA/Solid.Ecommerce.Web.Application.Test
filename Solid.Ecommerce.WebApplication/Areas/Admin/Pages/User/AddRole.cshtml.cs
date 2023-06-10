
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.WebApplication.Areas.Admin.Pages.User;
[Authorize(Roles = "Administrator")]
public class AddRoleModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AddRoleModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManage)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManage;
    }

    [TempData]
    public string StatusMessage { get; set; }

    public IdentityUser? user { get; set; }

    [BindProperty]
    [DisplayName("Các Role gán cho user")]
    public string[] RoleNames { get; set; }

    public SelectList allRoles { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound($"Does not exits user");
        }

        user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound($"Do not find user, id = {id}.");
        }
        RoleNames = (await _userManager.GetRolesAsync(user)).ToArray<string>();

        List<string> roleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
        allRoles = new SelectList(roleNames);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {

        if (string.IsNullOrEmpty(id))
        {
            return NotFound($"Does not exits user");
        }

        user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound($"Do not find user, id = {id}.");
        }
        //RoleNames
        var OldRoleNames = (await _userManager.GetRolesAsync(user)).ToArray();

        var deleteRoles = OldRoleNames.Where(r => !RoleNames.Contains(r));

        var addRoles = RoleNames.Where(r => !OldRoleNames.Contains(r));

        List<string> roleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
        allRoles = new SelectList(roleNames);

        var resultDelete = await _userManager.RemoveFromRolesAsync(user, deleteRoles);
        if(!resultDelete.Succeeded)
        {
            resultDelete.Errors.ToList().ForEach(error =>
            {
                ModelState.AddModelError(string.Empty, error.Description);
            });
            return Page();
        }
        var resultAdd = await _userManager.AddToRolesAsync(user, addRoles);

        if (!resultAdd.Succeeded)
        {
            resultAdd.Errors.ToList().ForEach(error =>
            {
                ModelState.AddModelError(string.Empty, error.Description);
            });
            return Page();
        }

        StatusMessage = $"You just update role for user: {user.UserName}";

        return RedirectToPage("./Index");
    }
}
