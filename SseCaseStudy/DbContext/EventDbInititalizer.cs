using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.DbContext
{
    public static class EventDbInititalizer
    {
        public static void Initialize(EventDbContext eventDbContext)
        {
            eventDbContext.Database.EnsureCreated();
        }
    }
}
