using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class QueueProvider
    {
        private readonly List<Song> _queue = new List<Song>();

        private void Play(Song song)
        {

        }

        public bool Next()
        {
            if (_queue.Count == 0) return false;
            Play(_queue[0]);
            _queue.RemoveAt(0);
            return true;
        }


        public void Add(Song song)
        {
            _queue.Add(song);
        }

        public void Add(List<Song> songs)
        {
            songs.ForEach(_queue.Add);
        }

        public bool Remove(Song song)
        {
            return _queue.Remove(song);
        }

        public void SetNext(Song song)
        {
            _queue.Insert(0, song);
        }
    }
}