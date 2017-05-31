using Killer_App.Helpers.Providers;

namespace Killer_App.Models
{
    public class BaseModel
    {
        public Provider Provider { get; set; }
        public string Error { get; protected set; }
        public string Sucess { get; protected set; }
        public string Warning { get; protected internal set; }

        protected static string InfoLink(string linkText, string actionName, string controllerName, int id)
        {
            return $@"<a href=""/{controllerName}/{actionName}/{id}"">{linkText}</a>";
        }
    }
}