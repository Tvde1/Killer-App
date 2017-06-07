using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    [DataContract]
    public class Song : BaseOject
    {
        private readonly IEnumerable<int> _albumIds;
        private readonly IEnumerable<int> _artistIds;

        public Song()
        {
        }

        public Song(int id, string name, TimeSpan duration, Provider provider)
        {
            Name = name;
            Id = id;
            Duration = duration;
            Provider = provider;

            _artistIds = Provider.ArtistProvider.GetArtistIds(this);
            _albumIds = Provider.AlbumProvider.GetAlbumIds(this);
        }
        

        [DataMember]
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }
        public List<Album> Albums => Provider.AlbumProvider.GetAlbums(_albumIds);

        [DataMember]
        public List<Artist> Artists => Provider.ArtistProvider.GetArtists(_artistIds);

        public override string ToString()
        {
            return Name;
        }

        public string LinkString()
        {
            return InfoLink(Name, "Song", "Info", Id);
        }
    }
}