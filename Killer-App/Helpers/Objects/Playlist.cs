﻿using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.Objects
{
    public class Playlist : BaseOject
    {
        private readonly int _ownerId;
        private readonly List<int> _songIds;

        public Playlist(Provider provider, int id, string name, int ownerId, List<int> songIds)
        {
            Id = id;
            Name = name;
            _ownerId = ownerId;
            _songIds = songIds;
            Provider = provider;
        }

        public string Name { get; }
        public User Owner => Provider.UserProvider.FetchUser(_ownerId);
        public List<Song> Songs => Provider.SongProvider.FetchSongs(_songIds);
    }
}