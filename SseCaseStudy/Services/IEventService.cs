using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SseCaseStudy.Models.EventModels;

namespace SseCaseStudy.Services
{
    public interface IEventService
    {
        Task RecordSearchEvent(SearchEvent searchEvent);
        Task RecordSongClickEvent(SongClickEvent songClickEvent);
    }
}
