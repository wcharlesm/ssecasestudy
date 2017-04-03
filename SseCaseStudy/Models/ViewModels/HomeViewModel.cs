using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Models.ViewModels
{
    public class HomeViewModel
    {
        public String SearchId { get; set; }
        public List<SearchResultDisplay> SearchResults { get; set; }
    }
}
