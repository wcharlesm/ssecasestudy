using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SseCaseStudy.DbContext;

namespace SseCaseStudy.Services
{
    public class ClickStatisticsService : IClickStatisticsService
    {
        private readonly EventDbContext _eventDbContext;

        public ClickStatisticsService(EventDbContext eventDbContext)
        {
            _eventDbContext = eventDbContext;
        }

        public int ClickCountBySearchOrder(int order)
        {
            return _eventDbContext.MediaItemClickEvent.Where(x => x.SearchOrder == order).Count();
        }

        public int TotalClickCount()
        {
            return _eventDbContext.MediaItemClickEvent.Count();
        }
    }
}
