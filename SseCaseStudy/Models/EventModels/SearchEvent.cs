using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Models.EventModels
{
    public class SearchEvent
    {
        public int ID { get; set; }
        public String UserId { get; set; }
        public String SearchId { get; set; }
        public String SearchTerm { get; set; }
        public String SearchType { get; set; }
        public DateTime TimeStamp { get; set; }

        public List<MediaItemClickEvent> MediaItemClickEvents { get; set; }
    }
}
