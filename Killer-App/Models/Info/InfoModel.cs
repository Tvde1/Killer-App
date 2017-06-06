using System.Collections;
using System.Collections.Generic;
using System.Net;
using Killer_App.Helpers.Api;
using Killer_App.Helpers.Objects;
using Newtonsoft.Json;
using Artist = Killer_App.Helpers.Objects.Artist;

namespace Killer_App.Models.Info
{
    public class InfoModel : BaseModel
    {
        public Song Song { get; set; }
        public Album Album { get; set; }
        public Artist Artist { get; set; }

        public string ArtistId { get; set; }
        public LastFmApi ArtistInfo { get; private set; }
        public List<Comment> Comments { get; set; }

        public void GetArtistImage()
        {
            if (Artist == null) return;
            using (var client = new WebClient())
            { 
                var json = client.DownloadString($"http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist={Artist.ArtistName}&api_key=c7560b702dbcf8f9fad518469d55c928&format=json");
                ArtistInfo = JsonConvert.DeserializeObject<LastFmApi>(json);
            }
        }
    }
}