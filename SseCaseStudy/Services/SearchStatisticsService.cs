using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SseCaseStudy.DbContext;

namespace SseCaseStudy.Services
{
    public class SearchStatisticsService : ISearchStatisticsService
    {
        private readonly EventDbContext _eventDbContext;

        public SearchStatisticsService(EventDbContext eventDbContext)
        {
            _eventDbContext = eventDbContext;
        }

        public int SearchesWithoutClicks()
        {
            var zeroClicks = _eventDbContext.SearchEvent.Where(se => se.MediaItemClickEvents.Count() == 0);

            return zeroClicks.Count();
        }

        public int TotalSearches()
        {
            return _eventDbContext.SearchEvent.Count();
        }
    }
}
