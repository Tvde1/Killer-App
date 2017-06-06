using System;
using System.Collections.Generic;
using System.Timers;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class QueueProvider
    {
        private readonly List<Song> _queue = new List<Song>();

        public Song CurrentSong { get; private set; }
        public TimeSpan AtTime { get; private set; }
        private readonly Provider _provider;

        private readonly Timer _songTimer = new Timer(100);

        public QueueProvider(Provider provider)
        {
            _provider = provider;

            Play(_provider.SongProvider.FetchSong("201"));

            _songTimer.Elapsed += (sender, args) => TimerTick();
        }

        private void Play(Song song)
        {
            CurrentSong = song;
            AtTime = TimeSpan.Zero;
            _songTimer.Enabled = true;
        }

        private void TimerTick()
        {
            if (CurrentSong.Duration.Subtract(AtTime).TotalMilliseconds < 100)
            {
                AtTime = CurrentSong.Duration;
                _songTimer.Enabled = false;
            }

            AtTime = AtTime.Add(new TimeSpan(0, 0, 0, 0, 100));
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

        public void Skip()
        {
            if (_queue.Count == 0) return;
            Play(_queue[0]);
            _queue.RemoveAt(0);
        }
    }
}