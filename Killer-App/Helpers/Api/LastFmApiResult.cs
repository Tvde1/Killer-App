using System.Collections.Generic;
using Newtonsoft.Json;

namespace Killer_App.Helpers.Api
{
    public class ApiImage
    {
        [JsonProperty("#text")]
        public string Text { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
    }

    public class Stats
    {
        [JsonProperty("listeners")]
        public string Listeners { get; set; }

        [JsonProperty("playcount")]
        public string Playcount { get; set; }
    }
    
    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Tags
    {
        [JsonProperty("tag")]
        public IList<Tag> Tag { get; set; }
    }

    public class Link
    {
        [JsonProperty("#text")]
        public string Text { get; set; }

        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class Links
    {
        [JsonProperty("link")]
        public Link Link { get; set; }
    }

    public class Bio
    {
        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("published")]
        public string Published { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class ApiArtist
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mbid")]
        public string Mbid { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public IList<ApiImage> Images { get; set; }
        
        [JsonProperty("stats")]
        public Stats Stats { get; set; }
        
        [JsonProperty("tags")]
        public Tags Tags { get; set; }

        [JsonProperty("bio")]
        public Bio Bio { get; set; }
    }

    public class LastFmApi
    {
        [JsonProperty("artist")]
        public ApiArtist Artist { get; set; }
    }
}
