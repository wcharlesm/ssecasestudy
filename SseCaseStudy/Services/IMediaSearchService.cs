using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SseCaseStudy.Models;

namespace SseCaseStudy.Services
{
    public interface IMediaSearchService
    {
        Task<List<SongSearchResult>> GetMovies(String searchTerm);
        Task<List<SongSearchResult>> GetMusicVideos(String searchTerm);
        Task<List<SongSearchResult>> GetSoftware(String searchTerm);
        Task<List<SongSearchResult>> GetSongs(String searchTerm);
        Task<List<SongSearchResult>> GetTvShowsBySeason(String searchTerm);
    }
}
