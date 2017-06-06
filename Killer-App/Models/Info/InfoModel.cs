using Killer_App.Helpers.Objects;

namespace Killer_App.Models.Info
{
    public class InfoModel : BaseModel
    {
        public Song Song { get; set; }

        public string ArtistId { get; set; }
    }
}