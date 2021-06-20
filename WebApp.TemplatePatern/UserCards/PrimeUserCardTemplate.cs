using System.Text;

namespace WebApp.TemplatePatern.UserCards
{
    public class PrimeUserCardTemplate : UserCardTemplate
    {
        protected override string SetFoouter()
        {
            var sb = new StringBuilder();
            sb.Append("<a href='#' class='card-link'>Mesaj Gonder</a>");
            sb.Append("<a href='#' class='card-link'>Detayli Profil</a>");
            return sb.ToString();
        }
        protected override string SetPicture()
        {
            
             return $"<img class='card-img-top' src='{AppUser.PictureUrl}'></img>";
        }
    }
}