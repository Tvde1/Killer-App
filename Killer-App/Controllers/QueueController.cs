using System.Web.Mvc;
using Killer_App.Helpers.Providers;
using Killer_App.Models.Playlist;
using Killer_App.Models.Queue;

namespace Killer_App.Controllers
{
    public class QueueController : BaseController
    {
        public ActionResult Index()
        {
            var provider = (Provider) Session["Provider"];
            if (provider == null) return GoToSignIn();

            var tempModel = TempData["QueueModel"] as QueueModel;
            if (tempModel != null)
                return View(tempModel);

            var model = new QueueModel {Provider = provider};
            model.UpdateItems();

            return View(model);
        }

        public ActionResult Skip()
        {
            var provider = (Provider) Session["Provider"];
            if (provider == null) return GoToSignIn();
            provider.QueueProvider.Skip();

            return Redirect(Request.UrlReferrer?.ToString());
        }

        public ActionResult PausePlay()
        {
            var provider = (Provider) Session["Provider"];
            if (provider == null) return GoToSignIn();

            provider.QueueProvider.StartStopTimer();

            return Redirect(Request.UrlReferrer?.ToString());
        }

        public ActionResult Play(string songid)
        {
            var provider = (Provider) Session["Provider"];
            if (provider == null) return GoToSignIn();
            provider.QueueProvider.Add(provider.SongProvider.FetchSong(songid));

            return Redirect(Request.UrlReferrer?.ToString());
        }

        public ActionResult Restart()
        {
            var provider = (Provider) Session["Provider"];
            if (provider == null) return GoToSignIn();
            provider.QueueProvider.Restart();

            return Redirect(Request.UrlReferrer?.ToString());
        }

        public ActionResult AddPlaylist(int id)
        {
            var provider = (Provider) Session["Provider"];
            if (provider == null) return GoToSignIn();

            var playlist = provider.PlaylistProvider.GetPlaylist(id.ToString());
            provider.QueueProvider.Add(playlist.Songs);

            var model = new PlaylistDetailsModel
            {
                Provider = provider,
                Playlist = playlist
            };
            TempData["TempPlaylistDetailsModel"] = model;
            return RedirectToAction("Details", "Playlist", new {id});
        }

        public ActionResult Remove(string id)
        {
            var provider = (Provider) Session["Provider"];
            if (provider == null) return GoToSignIn();

            var model = new QueueModel
            {
                Provider = provider
            };
            int newId;
            if (!int.TryParse(id, out newId))
                model.Error = "Something went wrong with sending the song id.";
            else if (!provider.QueueProvider.Remove(newId))
                model.Warning = "The song wasn't in the queue.";
            else
                model.Sucess = "Song removed!";

            TempData["QueueModel"] = model;

            return RedirectToAction("Index");
        }
    }
}