using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Strategy.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Strategy.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManger;

        public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManger = null)
        {
            _userManager = userManager;
            _signInManger = signInManger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            Settings settings = new();

            if (User.Claims.Where(x => x.Type == Settings.claimDatabaseType).FirstOrDefault() != null)
            {
                settings.DatabaseType = (EDatabaseType)int.Parse(User.Claims.First(x => x.Type == Settings.claimDatabaseType).Value);
            }
            else
            {
                settings.DatabaseType = settings.GetDefaultDatabaseType;
            }
            return View(settings);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeDatabase(int databaseType)
        {

            var user = await GetUsers();

            var newClaim = new Claim(Settings.claimDatabaseType, databaseType.ToString());

            var claims = await _userManager.GetClaimsAsync(user);

            var hasDatabaseTypeClaim = claims.FirstOrDefault(x => x.Type == Settings.claimDatabaseType);

            if (hasDatabaseTypeClaim != null)
            {
                await _userManager.ReplaceClaimAsync(user, hasDatabaseTypeClaim, newClaim);
            }
            else
            {
                await _userManager.AddClaimAsync(user, newClaim);
            }

            await _signInManger.SignOutAsync();

            var authenticateResult = await HttpContext.AuthenticateAsync();

            await _signInManger.SignInAsync(user, authenticateResult.Properties);

            return RedirectToAction(nameof(Index));
        }



        private async Task<AppUser> GetUsers()
        {
            return await _userManager.FindByNameAsync(User.Identity.Name);
        }
    }
}
