using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Models.EventModels
{
    public class MediaItemClickEvent
    {
        public int ID { get; set; }
        public String UserId { get; set; }
        public String MediaId { get; set; }
        public String MediaLink { get; set; }
        public int SearchOrder { get; set; }
        public String SearchId { get; set; }
        public String SearchTerm { get; set; }
        public String Title { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
