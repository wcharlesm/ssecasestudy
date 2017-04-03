using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SseCaseStudy.Models.ViewModels;

namespace SseCaseStudy.Services
{
    public interface IMediaSearchService
    {
        Task<List<SearchResultDisplay>> GetMovies(String searchTerm);
        Task<List<SearchResultDisplay>> GetMusicVideos(String searchTerm);
        Task<List<SearchResultDisplay>> GetSoftware(String searchTerm);
        Task<List<SearchResultDisplay>> GetSongs(String searchTerm);
        Task<List<SearchResultDisplay>> GetTvShowsBySeason(String searchTerm);
    }
}
