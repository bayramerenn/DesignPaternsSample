using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.TemplatePatern.Models
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser>
    {
       public AppIdentityDbContext (DbContextOptions<AppIdentityDbContext> options) : base (options) { }
    }
}