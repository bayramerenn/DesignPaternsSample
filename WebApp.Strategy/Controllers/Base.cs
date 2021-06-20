using System.Threading.Tasks;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Strategy.Controllers
{
    public class Base : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public Base(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

       

        private async Task<AppUser> GetUsers() => await _userManager.FindByNameAsync(User.Identity.Name);
    }
}