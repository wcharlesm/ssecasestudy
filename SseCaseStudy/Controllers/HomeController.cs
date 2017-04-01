using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SseCaseStudy.ActionFilters;
using SseCaseStudy.EventModels;
using SseCaseStudy.Models;
using SseCaseStudy.Services;

namespace SseCaseStudy.Controllers
{
    
    public class HomeController : Controller
    {
        private IEventService _eventService;
        private IMediaSearchService _searchService;

        public HomeController(IEventService eventService, IMediaSearchService songSearchService)
        {
            _eventService = eventService;
            _searchService = songSearchService;
            
        }

        [IdFilter]
        public async Task<IActionResult> Index(string searchTerm, string searchType)
        {
            var id = this.HttpContext.Request.Cookies["ssecasestudycookie"];

            if (String.IsNullOrEmpty(searchTerm))
            {
                return View(new List<SearchResult>());
            }
            else
            {

                _eventService.RecordSearchEvent(new SearchEvent
                {
                    UserId = id,
                    SearchTerm = searchTerm,
                    SearchType = searchType,
                    TimeStamp = DateTime.Now
                });

                List<SearchResultDisplay> results;

                switch (searchType)
                {
                    case "Songs":
                        results = await _searchService.GetSongs(searchTerm);
                        break;

                    case "Music Videos":
                        results = await _searchService.GetMusicVideos(searchTerm);
                        break;

                    case "Movies":
                        results = await _searchService.GetMovies(searchTerm);
                        break;

                    case "TV Shows":
                        results = await _searchService.GetTvShowsBySeason(searchTerm);
                        break;

                    case "Software":
                        results = await _searchService.GetSoftware(searchTerm);
                        break;

                    default:
                        results = await _searchService.GetSongs(searchTerm);
                        break;

                }

                return View(results);
            }
        }

        public IActionResult RedirectToITunes()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}
