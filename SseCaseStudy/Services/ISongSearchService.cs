using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SseCaseStudy.Models;

namespace SseCaseStudy.Services
{
    public interface ISongSearchService
    {
        Task<List<SongSearchResult>> GetSongs(String searchTerm);
    }
}
