using System.Web.Mvc;
using Killer_App.App_Data.Providers;
using Killer_App.Models.Home;
using Killer_App.Models.Signin;

namespace Killer_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            var model = new IndexModel { Provider = provider };
            return View(model);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var provider = (Provider)Session["Provider"];
            return provider == null ? GoToSignIn() : View(new SearchModel { Provider = provider });
        }

        //POST and GET: Search.
        [HttpPost]
        public ActionResult Search(SearchModel model)
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            model.Provider = provider;
            if (!string.IsNullOrEmpty(model.SearchText)) model.Search();
            return View(model);
        }

        //GET: Stats
        public ActionResult Stats()
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            var model = new StatsModel { Provider = provider };
            return View(model);
        }

        private ActionResult GoToSignIn()
        {
            TempData["SigninModel"] = new SigninModel {Error = "You were not logged in."};
            return RedirectToAction("Index", "Signin");
        }
    }
}