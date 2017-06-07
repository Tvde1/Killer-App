using System;
using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.Objects;

namespace Killer_App.Models.Queue
{
    public class QueueModel : BaseModel
    {
        public List<Song> Queue { get; set; }
        public Song NowPlaying { get; set; }
        public TimeSpan AtTime { get; set; }

        public void UpdateItems()
        {
            Queue = Provider.QueueProvider.Queue.ToList();
            NowPlaying = Provider.QueueProvider.CurrentSong;
            AtTime = Provider.QueueProvider.AtTime;
        }
    }
}