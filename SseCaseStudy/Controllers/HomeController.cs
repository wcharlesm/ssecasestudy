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
                return View(new HomeViewModel {
                    SearchResults = new List<SearchResultDisplay>()
                });
            }
            else
            {
                var searchId = Guid.NewGuid().ToString();

                var searchEvent = new SearchEvent
                {
                    UserId = id,
                    SearchId = searchId,
                    SearchTerm = searchTerm,
                    SearchType = searchType,
                    TimeStamp = DateTime.Now
                };

                await _eventService.RecordSearchEvent(searchEvent);

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

                for (var i = 0; i < results.Count; i++)
                {
                    results[i].Link = RedirectUrl(results[i], searchId, searchTerm, i);
                }

                return View(new HomeViewModel {
                    SearchId = searchId,
                    SearchResults = results
                });
            }
        }

        private String RedirectUrl(SearchResultDisplay result, String searchId, String searchTerm, int searchOrder) {
            var parameters = new Dictionary<String, String> {
                {"itunesLink", result.Link },
                {"resourceId", result.ResourceId },
                {"searchId",  searchId },
                {"searchOrder", searchOrder.ToString() },
                {"searchTerm", searchTerm },
                {"title", result.Title }
            };

            return QueryHelpers.AddQueryString("/Home/RedirectToITunes", parameters);
        }

        public async Task<IActionResult> RedirectToITunes(String itunesLink, String resourceId, String searchId, int searchOrder, String searchTerm, String title)
        {
            var userId = this.HttpContext.Request.Cookies["ssecasestudycookie"];

            var clickEvent = new MediaItemClickEvent
            {
                UserId = userId,
                MediaId = resourceId,
                MediaLink = itunesLink,
                SearchId = searchId,
                SearchTerm = searchTerm,
                Title = title,
                SearchOrder = searchOrder,
                TimeStamp = DateTime.Now
            };

            await _eventService.RecordMediaItemClickEvent(clickEvent);

            return Redirect(itunesLink);
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}
