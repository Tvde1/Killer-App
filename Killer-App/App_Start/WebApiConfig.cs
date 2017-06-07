using System.Web.Http;

namespace Killer_App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable attribute routing
            config.MapHttpAttributeRoutes();

            // Add default route using convention-based routing
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}",
                new {controller = "RandomSong"}
            );
        }
    }
}