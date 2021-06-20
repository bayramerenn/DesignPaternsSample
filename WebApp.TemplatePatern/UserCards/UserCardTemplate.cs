using System;
using System.Text;
using WebApp.TemplatePatern.Models;

namespace WebApp.TemplatePatern.UserCards
{
    public abstract class UserCardTemplate
    {
        public AppUser AppUser { get; set; }
        public void SetUser(AppUser user)
        {
            AppUser = user;
        }

        public string Build()
        {
            if (AppUser == null) throw new ArgumentNullException(nameof(AppUser));

            var sb = new StringBuilder();

            sb.Append("<div classs='card'>");
            sb.Append(SetPicture());
            sb.Append($@"<div class='card-body'>
                            <h5>{AppUser.UserName}</h5>
                            <p>{AppUser.Description}</p>
                    ");
            sb.Append(SetFoouter());
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();


        }
        protected virtual string SetFoouter()
        {
            return String.Empty;
        }
        protected abstract string SetPicture();
    }
}