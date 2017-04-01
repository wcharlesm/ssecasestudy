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
        private ISongSearchService _songSearchService;

        public HomeController(IEventService eventService, ISongSearchService songSearchService)
        {
            _eventService = eventService;
            _songSearchService = songSearchService;
            
        }

        [IdFilter]
        public async Task<IActionResult> Index(string searchTerm)
        {
            var id = this.HttpContext.Request.Cookies["ssecasestudycookie"];

            if (String.IsNullOrEmpty(searchTerm))
            {
                return View(new List<SongSearchResult>());
            }
            else
            {

                _eventService.RecordSearchEvent(new SearchEvent
                {
                    UserId = id,
                    SearchTerm = searchTerm,
                    TimeStamp = DateTime.Now
                });

                var songs = await _songSearchService.GetSongs(searchTerm);
                return View(songs);
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
