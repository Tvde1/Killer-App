using System;
using System.Collections.Generic;
using Killer_App.Helpers.DAL.Contexts;
using Killer_App.Helpers.DAL.Interfaces;
using Killer_App.Helpers.Objects;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers.DAL.Repositories
{
    internal class AlbumRepository
    {
        private static readonly Random Rnd = new Random();
        private readonly IAlbumContext _albumContext;
        private readonly ObjectCreator _objectCreator;
        private readonly ISongContext _songContext;

        public AlbumRepository(Provider provider, ContextBase contextBase)
        {
            _albumContext = new MssqlAlbumContext(contextBase);
            _objectCreator = new ObjectCreator(provider);
            _songContext = new MssqlSongContext(contextBase);
        }

        public IEnumerable<int> GetAlbumIds(Song song)
        {
            return ObjectCreator.CreateList(_albumContext.GetAlbums(song), row => (int) row["AlbumCk"]);
        }

        public IEnumerable<int> GetAlbumIds(Artist artist)
        {
            return ObjectCreator.CreateList(_albumContext.GetAlbums(artist), row => (int) row["AlbumCk"]);
        }

        public List<Album> FetchAlbums(IEnumerable<int> list)
        {
            return ObjectCreator.CreateList(_albumContext.FetchAlbums(list), _objectCreator.CreateAlbum);
        }

        public void AssignAlumArtists()
        {
            var albumIds = ObjectCreator.CreateList(_albumContext.GetAlbums(), row => (int) row["AlbumPk"]);
            var songIds = ObjectCreator.CreateList(_songContext.GetSongs(), row => (int) row["SongPk"]);

            foreach (var songId in songIds)
            {
                var albumId = albumIds[Rnd.Next(albumIds.Count)];
                _albumContext.AddToSong(albumId, songId);
            }
        }
    }
}