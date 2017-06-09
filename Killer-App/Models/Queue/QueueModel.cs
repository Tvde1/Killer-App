using System.Collections.Generic;
using System.Linq;
using Killer_App.Helpers.Objects;

namespace Killer_App.Models.Queue
{
    public class QueueModel : BaseModel
    {
        public List<Song> Queue { get; private set; }
        public Song NowPlaying { get; private set; }

        public void UpdateItems()
        {
            Queue = Provider.QueueProvider.Queue.ToList();
            NowPlaying = Provider.QueueProvider.CurrentSong;
        }
    }
}