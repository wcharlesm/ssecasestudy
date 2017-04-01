using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SseCaseStudy.EventModels;

namespace SseCaseStudy.Services
{
    public class EventService : IEventService
    {
        public Task RecordSearchEvent(SearchEvent searchEvent)
        {
            return null;
            //throw new NotImplementedException();
        }

        public Task RecordSongClickEvent(SongClickEvent songClickEvent)
        {

            return null;
            //throw new NotImplementedException();
        }
    }
}
