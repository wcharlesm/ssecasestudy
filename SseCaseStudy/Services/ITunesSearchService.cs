using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SseCaseStudy.Models;

namespace SseCaseStudy.Services
{
    public class ITunesSearchService : IMediaSearchService
    {
        private readonly IRestClient _restClient;

        public ITunesSearchService(IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.BaseUrl = new System.Uri("https://itunes.apple.com");
        }

        public async Task<List<SongSearchResult>> GetMovies(string searchTerm)
        {
            var results = await SearchITunes<SongSearchResult>(searchTerm, "movie");

            return results;
        }

        public async Task<List<SongSearchResult>> GetMusicVideos(string searchTerm)
        {
            var results = await SearchITunes<SongSearchResult>(searchTerm, "musicVideo");

            return results;
        }

        public async Task<List<SongSearchResult>> GetSoftware(string searchTerm)
        {
            var results = await SearchITunes<SongSearchResult>(searchTerm, "software");

            return results;
        }

        public async Task<List<SongSearchResult>> GetSongs(string searchTerm)
        {
            var results = await SearchITunes<SongSearchResult>(searchTerm, "song");

            return results;
        }

        public async Task<List<SongSearchResult>> GetTvShowsBySeason(string searchTerm)
        {
            var results = await SearchITunes<SongSearchResult>(searchTerm, "tvSeason");

            return results;
        }

        private async Task<List<ResultType>> SearchITunes<ResultType>(string searchTerm, string entityType)
        {
            var normalizedSearchTerm = searchTerm.Replace(" ", "+");

            var request = new RestRequest("search");
            request.AddParameter("term", normalizedSearchTerm);
            request.AddParameter("entity", entityType);

            var taskCompletion = new TaskCompletionSource<IRestResponse<ITunesSearchResponse<ResultType>>>();

            RestRequestAsyncHandle handle = _restClient.ExecuteAsync<ITunesSearchResponse<ResultType>>(request, x => taskCompletion.SetResult(x));

            var response = await taskCompletion.Task;

            return response.Data.Results;
        }
    }
}
