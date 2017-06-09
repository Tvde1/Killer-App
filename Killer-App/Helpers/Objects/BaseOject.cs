using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public abstract class BaseOject
    {
        protected Provider Provider;
        public int Id { get; set; }

        protected static string InfoLink(string linkText, string actionName, string controllerName, int id)
        {
            return $@"<a href=""/{controllerName}/{actionName}/{id}"">{linkText}</a>";
        }
    }
}