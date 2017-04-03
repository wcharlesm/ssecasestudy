using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Models.ITunesSearchModels
{
    public class SearchResult
    {
        public String ArtistName { get; set; }
        public String CollectionName { get; set; }
        public String CollectionPrice { get; set; }
        public String Description { get; set; }
        public String FormattedPrice { get; set; }
        public String LongDescription { get; set; }
        public String Price { get; set; }
        public List<String> SupportedDevices { get; set; }
        public String TrackName { get; set; }
        public String TrackPrice { get; set; }
        public String TrackViewUrl { get; set; }
        public int TrackId { get; set; }

    }
}
