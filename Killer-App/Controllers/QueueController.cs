using System.Web.Mvc;
using Killer_App.Helpers.Providers;
using Killer_App.Models.Queue;

namespace Killer_App.Controllers
{
    public class QueueController : BaseController
    {
        public ActionResult Index()
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();

            var tempModel = TempData["QueueModel"] as QueueModel;
            if (tempModel != null)
                return View(tempModel);

            var model = new QueueModel { Provider = provider };
            model.UpdateItems();

            return View(model);
        }

        public ActionResult Skip()
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            provider.QueueProvider.Skip();

            return Redirect(Request.UrlReferrer?.ToString());
        }

        public ActionResult PausePlay()
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();

            provider.QueueProvider.StartStopTimer();

            return Redirect(Request.UrlReferrer?.ToString());
        }

        public ActionResult Play(string songid)
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            provider.QueueProvider.Add(provider.SongProvider.FetchSong(songid));

            return Redirect(Request.UrlReferrer?.ToString());
        }

        public ActionResult Restart()
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            provider.QueueProvider.Restart();

            return Redirect(Request.UrlReferrer?.ToString());
        }
    }
}