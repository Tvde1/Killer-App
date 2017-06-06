using Killer_App.Helpers.Providers;

namespace Killer_App.Models
{
    public class BaseModel
    {
        public Provider Provider { get; set; }
        public string Error { get; set; }
        public string Sucess { get; set; }
        public string Warning { get; set; }

        protected static string InfoLink(string linkText, string actionName, string controllerName, int id)
        {
            return $@"<a href=""/{controllerName}/{actionName}/{id}"">{linkText}</a>";
        }
    }
}