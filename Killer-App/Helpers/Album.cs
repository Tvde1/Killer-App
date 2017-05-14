using System.Collections.Generic;
using Killer_App.Helpers.Providers;

namespace Killer_App.Helpers
{
    internal class Album
    {
        private Provider _provider;

        public int Id { get; }
        public string Name { get; }

        public Album(int id, string name, Provider provider)
        {
            Id = id;
            Name = name;
            _provider = provider;
        }

        public List<Song> Songs { get; } //TODO: Hook up to
        public List<Artist> Artists { get; } //TODO: Hook up
    }
}