using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Models.ViewModels
{
    public class ClickStatisticsViewModel
    {
        public int TotalClicks { get; set; }
        public Dictionary<int, int> ClicksBySearchOrder { get; set; }
        public int LeftOverClicks { get; set; }
    }
}
