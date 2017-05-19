using System.Web.Mvc;
using Killer_App.App_Data.Helpers.DAL.Providers;
using Killer_App.Models.Signin;

namespace Killer_App.Controllers
{
    public class SigninController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SigninModel model)
        {
            if (Session["Provider"] == null) Session["Provider"] = model.Provider ?? new Provider();
            model.Provider = Session["Provider"] as Provider;

            var result = Session["Provider"] as Provider;

            return View(model);
        }
    }
}