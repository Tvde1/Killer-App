using System.Web.Mvc;
using Killer_App.Models.Signin;

namespace Killer_App.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult GoToSignIn()
        {
            return RedirectToAction("Index", "Signin", new SigninModel { Error = "You were not logged in." });
        }
    }
}