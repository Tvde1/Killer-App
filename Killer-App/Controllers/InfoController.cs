using System.Web.Mvc;
using Killer_App.Helpers.Providers;

namespace Killer_App.Controllers
{
    public class InfoController : BaseController
    {
        // GET: Info
        public ActionResult Song(string id)
        {
            if (id == null) return RedirectToAction("Index", "Home");

            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            
            var song = provider.SongProvider.FetchSong(id);
            if (song == null) return RedirectToAction("Index", "Home");

            return View(song);
        }

        public ActionResult Album(string id)
        {
            if (id == null) return RedirectToAction("Index", "Home");

            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            
            var album = provider.AlbumProvider.FetchAlbum(id);
            if (album == null) return RedirectToAction("Index", "Home");

            return View(album);
        }

        public ActionResult Artist(string id)
        {
            if (id == null) return RedirectToAction("Index", "Home");

            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            
            var artist = provider.ArtistProvider.FetchArtist(id);
            if (artist == null) return RedirectToAction("Index", "Home");
            return View(artist);
        }
    }
}