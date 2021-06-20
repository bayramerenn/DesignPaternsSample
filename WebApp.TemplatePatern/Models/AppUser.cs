using Microsoft.AspNetCore.Identity;

namespace WebApp.TemplatePatern.Models
{
    public class AppUser:IdentityUser
    {
          public string PictureUrl { get; set; }
          public string Description { get; set; }
          
    }
}