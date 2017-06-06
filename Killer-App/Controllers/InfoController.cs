using System.Web.Mvc;
using Killer_App.Helpers.Providers;
using Killer_App.Models.Info;

namespace Killer_App.Controllers
{
    public class InfoController : BaseController
    {
        // GET: Info
        public ActionResult Song(string id)
        {
            var model = (InfoModel) TempData["SongInfoModel"];
            if (model != null)
                return View(model);

            if (id == null) return RedirectToAction("Index", "Home");

            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            
            var song = provider.SongProvider.FetchSong(id);
            if (song == null) return RedirectToAction("Index", "Home");

            var newModel = new InfoModel {Song = song, Provider = provider};

            return View(newModel);
        }

        public ActionResult Album(string id)
        {
            //var model = (InfoModel)TempData["AlbumInfoModel"];
            //if (model != null)
            //    return View(model);

            if (id == null) return RedirectToAction("Index", "Home");

            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            
            var album = provider.AlbumProvider.FetchAlbum(id);
            if (album == null) return RedirectToAction("Index", "Home");

            return View(album);
        }

        public ActionResult Artist(string id)
        {
            //var model = (InfoModel)TempData["ArtistInfoModel"];
            //if (model != null)
            //    return View(model);

            if (id == null) return RedirectToAction("Index", "Home");

            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();
            
            var artist = provider.ArtistProvider.FetchArtist(id);
            if (artist == null) return RedirectToAction("Index", "Home");
            return View(artist);
        }

        public ActionResult AddArtistToSong(InfoModel model)
        {
            var provider = (Provider)Session["Provider"];
            if (provider == null) return GoToSignIn();

            var newModel = new InfoModel();
            newModel.Song = provider.SongProvider.FetchSong(model.Song.Id.ToString());
            newModel.Provider = provider;

            int artistId;

            if (!int.TryParse(model.ArtistId, out artistId))
                newModel.Error = "The artist id is invalid.";
            else if (!provider.ArtistProvider.AddToSong(artistId, model.Song.Id))
                newModel.Error = "Something went wrong with adding the artist to the song.";
            else
                newModel.Sucess = "Added artist to song!";

            TempData["SongInfoModel"] = newModel;

            return RedirectToAction("Song");
        }
    }
}