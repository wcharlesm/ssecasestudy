using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Models.ViewModels
{
    public class SearchResultDisplay
    {
        public int ResourseId { get; set; }
        public String Title { get; set; }
        public String Link { get; set; }
        public String Price { get; set; }
        public List<String> DetailedDescription { get; set; }
    }
}
