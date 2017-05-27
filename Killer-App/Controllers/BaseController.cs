using System.Web.Mvc;
using Killer_App.Models.Signin;

namespace Killer_App.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult GoToSignIn()
        {
            TempData["SigninModel"] = new SigninModel { Error = "You were not logged in." };
            return RedirectToAction("Index", "Signin");
        }
    }
}