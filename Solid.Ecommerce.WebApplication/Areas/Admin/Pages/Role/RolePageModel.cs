using Microsoft.AspNetCore.Identity;
using Solid.Ecommerce.WebApplication.Data;

namespace Solid.Ecommerce.WebApplication.Areas.Admin.Pages.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly ApplicationDbContextIdentity _dbContextIdentity;

        [TempData]
        public string StatusMessage { get; set; }
        public RolePageModel(RoleManager<IdentityRole> roleManager, ApplicationDbContextIdentity dbContextIdentity)
        {
            _roleManager = roleManager;
            _dbContextIdentity = dbContextIdentity;
        }
    }
}
