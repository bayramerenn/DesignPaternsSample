namespace WebApp.TemplatePatern.UserCards
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {
        protected override string SetPicture()
        {
            return $"<img class='card-img-top' src='/userpictures/emptyuser.png'></img>";
        }
    }
}