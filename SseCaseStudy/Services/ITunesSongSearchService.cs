using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SseCaseStudy.Models;

namespace SseCaseStudy.Services
{
    public class ITunesSongSearchService : ISongSearchService
    {
        private readonly IRestClient _restClient;

        public ITunesSongSearchService(IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.BaseUrl = new System.Uri("https://itunes.apple.com");
        }

        public async Task<List<SongSearchResult>> GetSongs(string searchTerm)
        {
            var normalizedSearchTerm = searchTerm.Replace(" ", "+");

            var request = new RestRequest("search");
            request.AddParameter("term", normalizedSearchTerm);

            var taskCompletion = new TaskCompletionSource<IRestResponse<ITunesSearchResponse>>();

            RestRequestAsyncHandle handle = _restClient.ExecuteAsync<ITunesSearchResponse>(request, x => taskCompletion.SetResult(x));
  
            var response = await taskCompletion.Task;

            return response.Data.results;
        }
    }
}
