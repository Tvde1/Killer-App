using System.Web.Mvc;
using Killer_App.Helpers.Providers;

namespace Killer_App.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Song()
        {
            var provider = (Provider)Session["Provider"];

            var id = Request.Params["id"];
            if (id == null) return RedirectToAction("Index", "Home");
            
            var song = provider.SongProvider.FetchSong(id);
            if (song == null) return RedirectToAction("Index", "Home");

            return View(song);
        }

        public ActionResult Album()
        {
            var provider = (Provider)Session["Provider"];

            var id = Request.Params["id"];
            if (id == null) return RedirectToAction("Index", "Home");

            var album = provider.AlbumProvider.FetchAlbum(id);
            if (album == null) return RedirectToAction("Index", "Home");

            return View(album);
        }

        public ActionResult Artist()
        {
            var provider = (Provider)Session["Provider"];

            var id = Request.Params["id"];
            if (id == null) return RedirectToAction("Index", "Home");

            var artist = provider.ArtistProvider.FetchArtist(id);
            if (artist == null) return RedirectToAction("Index", "Home");
            return View(artist);
        }
    }
}