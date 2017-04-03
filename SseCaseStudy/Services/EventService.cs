using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SseCaseStudy.DbContext;
using SseCaseStudy.Models.EventModels;

namespace SseCaseStudy.Services
{
    public class EventService : IEventService
    {
        private readonly EventDbContext _eventDbContext;

        public EventService(EventDbContext eventDbContext) {
            _eventDbContext = eventDbContext;
        }
        public Task RecordSearchEvent(SearchEvent searchEvent)
        {
            _eventDbContext.SearchEvent.Add(searchEvent);
            return _eventDbContext.SaveChangesAsync();
        }

        public Task RecordMediaItemClickEvent(MediaItemClickEvent mediaItemClickEvent)
        {
            _eventDbContext.MediaItemClickEvent.Add(mediaItemClickEvent);
            return _eventDbContext.SaveChangesAsync();
        }
    }
}
