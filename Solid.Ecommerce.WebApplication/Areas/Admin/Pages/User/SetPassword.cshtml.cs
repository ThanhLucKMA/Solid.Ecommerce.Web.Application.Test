
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solid.Ecommerce.WebApplication.Areas.Admin.Pages.User;
[Authorize]
[Authorize(Roles = "Administrator")]
public class SetPasswordModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public SetPasswordModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    [TempData]
    public string StatusMessage { get; set; }
 
    public class InputModel
    { 
        [Required(ErrorMessage ="Must Enter {0}")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

      
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }


    public IdentityUser? user { get; set; }

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

      /*  var hasPassword = await _userManager.HasPasswordAsync(user);

        if (hasPassword)
        {
            return RedirectToPage("./ChangePassword");
        }*/

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

        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _userManager.RemovePasswordAsync(user);

        var addPasswordResult = await _userManager.AddPasswordAsync(user, Input.NewPassword);
        if (!addPasswordResult.Succeeded)
        {
            foreach (var error in addPasswordResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }
    
        StatusMessage = $"You just update password for user: {user.UserName}";

        return RedirectToPage("./Index");
    }
}
