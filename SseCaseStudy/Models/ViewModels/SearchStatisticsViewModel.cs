using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Models.ViewModels
{
    public class SearchStatisticsViewModel
    {
        public int TotalSearches { get; set; }
        public int SearchesWithoutClicks { get; set; }
    }
}
