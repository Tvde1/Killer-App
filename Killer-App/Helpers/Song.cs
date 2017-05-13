using System;

namespace Killer_App.Helpers
{
    public class Song
    {
        public string Name { get; }
        public string Album { get; }
        public TimeSpan Duration { get; }

        public Song(string name, string album, TimeSpan duration)
        {
            Name = name;
            Album = album;
            Duration = duration;
        }
    }
}