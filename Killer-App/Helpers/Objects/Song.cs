﻿using System;
using System.Collections.Generic;
using Killer_App.Helpers.Providers;
using Killer_App.Models;

namespace Killer_App.Helpers.Objects
{
    public class Song : BaseModel
    {
        private readonly IEnumerable<int> _albumIds;
        private readonly IEnumerable<int> _artistIds;

        public int Id { get; }
        public string Name { get; }
        public TimeSpan Duration { get; }
        public List<Album> Albums => Provider.AlbumProvider.GetAlbums(_albumIds);

        public List<Artist> Artists => Provider.ArtistProvider.GetArtists(_artistIds);

        public Song(int id, string name, TimeSpan duration, Provider provider)
        {
            Name = name;
            Id = id;
            Duration = duration;
            Provider = provider;

            _artistIds = Provider.ArtistProvider.GetArtistIds(this);
            _albumIds = Provider.AlbumProvider.GetAlbumIds(this);
        }
    }
}