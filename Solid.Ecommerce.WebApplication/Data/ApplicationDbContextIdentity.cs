using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.WebApplication.Data
{
    public class ApplicationDbContextIdentity : IdentityDbContext
    {
        public ApplicationDbContextIdentity(DbContextOptions<ApplicationDbContextIdentity> options)
            : base(options)
        {
        }
    }
}