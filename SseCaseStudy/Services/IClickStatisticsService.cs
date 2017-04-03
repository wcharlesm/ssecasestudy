using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Services
{
    public interface IClickStatisticsService
    {
        int TotalClickCount();
        int ClickCountBySearchOrder(int rank);
    }
}
