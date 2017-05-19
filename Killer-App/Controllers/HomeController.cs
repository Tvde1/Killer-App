using System.Web.Mvc;
using Killer_App.App_Data.Helpers.DAL.Providers;
using Killer_App.Models;

namespace Killer_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["Provider"] == null) Session["Provider"] = new Provider();
            var model = new IndexModel();
            model.Provider = Session["Provider"] as Provider;
            model.RefreshTopSongs();
            return View(model);
        }

        [HttpGet]
        public ActionResult Search()
        {
            if (Session["Provider"] == null) Session["Provider"] = new Provider();
            return View(new SearchModel { Provider = Session["Provider"] as Provider });
        }

        //POST and GET: Search.
        [HttpPost]
        public ActionResult Search(SearchModel model)
        {
            if (Session["Provider"] == null)
                Session["Provider"] = model.Provider ?? new Provider();

            model.Provider = Session["Provider"] as Provider;

            if (!string.IsNullOrEmpty(model.SearchText)) model.Search();

            return View(model);
        }

        //GET: Stats
        public ActionResult Stats()
        {
            var model = new StatsModel { Provider = Session["Provider"] as Provider ?? new Provider() };
            return View(model);
        }
    }
}