using System;
using System.Web.Mvc;
using Killer_App.Helpers.Providers;
using Killer_App.Models.Home;
using Killer_App.Models.Signin;

namespace Killer_App.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            var model = new IndexModel(provider);
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
            if (model == null) throw new Exception("wha");
            Session["Provider"] = model.Provider;
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
    }
}