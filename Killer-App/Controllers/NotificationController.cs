using System.Web.Mvc;
using Killer_App.Helpers.Providers;
using Killer_App.Models.Notification;

namespace Killer_App.Controllers
{
    public class NotificationController : BaseController
    {
        public ActionResult Index()
        {
            var provider = Session["Provider"] as Provider;
            if (provider == null) return GoToSignIn();

            var model = new NotificationModel(provider);

            return View(model);
        }
    }
}