using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.EventModels
{
    public class SongClickEvent
    {
        public String UserId { get; set; }
        public String SongId { get; set; }
        public int SearchOrder { get; set; }
        public string SearchTerm { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
