using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using SseCaseStudy.ActionFilters;
using SseCaseStudy.Models.EventModels;
using SseCaseStudy.Models.ITunesSearchModels;
using SseCaseStudy.Models.ViewModels;
using SseCaseStudy.Services;

namespace SseCaseStudy.Controllers
{

    public class StatisticsController : Controller
    {
        private IClickStatisticsService _clickStatisticsService;

        public StatisticsController(IClickStatisticsService clickStatisticsService)
        {
            _clickStatisticsService = clickStatisticsService;
        }

        public IActionResult Index()
        {
            var totalClicks = _clickStatisticsService.TotalClickCount();
            var clicksBySearchOrder = new Dictionary<int, int> {
                        { 0, _clickStatisticsService.ClickCountBySearchOrder(0) },
                        { 1, _clickStatisticsService.ClickCountBySearchOrder(1) },
                        { 2, _clickStatisticsService.ClickCountBySearchOrder(2) }
                    };

            return View(new StatisticsViewModel {
                ClickStatistics = new ClickStatisticsViewModel {
                    TotalClicks = totalClicks,
                    ClicksBySearchOrder = clicksBySearchOrder,
                    LeftOverClicks = totalClicks - clicksBySearchOrder.Aggregate(0, (x, y) => x + y.Value)
                }
            });
        }

    }
}