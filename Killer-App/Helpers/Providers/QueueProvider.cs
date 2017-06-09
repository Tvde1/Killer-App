using System;
using System.Collections.Generic;
using System.Timers;
using Killer_App.Helpers.Objects;

namespace Killer_App.Helpers.Providers
{
    public class QueueProvider
    {
        private readonly Provider _provider;
        private readonly List<Song> _queue = new List<Song>();
        private readonly Timer _songTimer = new Timer(100);

        public QueueProvider(Provider provider)
        {
            _provider = provider;
            //Play(provider.SongProvider.FetchSong("201"));
            _songTimer.Elapsed += (sender, args) => TimerTick();
        }

        public Song CurrentSong { get; private set; }
        public TimeSpan AtTime { get; private set; }
        public bool Playing => _songTimer.Enabled;

        public IReadOnlyList<Song> Queue => _queue;

        private void Play(Song song)
        {
            CurrentSong = song;
            AtTime = TimeSpan.Zero;
            _songTimer.Enabled = true;
        }

        private void TimerTick()
        {
            if (CurrentSong == null)
            {
                _songTimer.Enabled = false;
                return;
            }

            if (CurrentSong.Duration.Subtract(AtTime).TotalMilliseconds < 100)
                Skip();

            AtTime = AtTime.Add(new TimeSpan(0, 0, 0, 0, 100));
        }

        public void Add(Song song)
        {
            _queue.Add(song);
            if (CurrentSong == null)
                Skip();
        }

        public void Add(IEnumerable<Song> songs)
        {
            _queue.AddRange(songs);
            if (CurrentSong == null)
                Skip();
        }

        public bool Remove(int songId)
        {
            var song = _provider.SongProvider.FetchSong(songId.ToString());
            return _queue.Remove(song);
        }

        public void SetNext(Song song)
        {
            _queue.Insert(0, song);
        }

        public void Skip()
        {
            if (_queue.Count == 0)
            {
                CurrentSong = null;
                AtTime = TimeSpan.Zero;
                _songTimer.Enabled = false;
            }
            else
            {
                Play(_queue[0]);
                _queue.RemoveAt(0);
            }
        }

        public void StartStopTimer()
        {
            _songTimer.Enabled = !_songTimer.Enabled;
        }

        public void Restart()
        {
            if (CurrentSong != null)
                AtTime = TimeSpan.Zero;

            _songTimer.Enabled = true;
        }
    }
}