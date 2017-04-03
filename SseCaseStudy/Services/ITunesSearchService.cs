using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SseCaseStudy.Models.ITunesSearchModels;
using SseCaseStudy.Models.ViewModels;

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

        public async Task<List<SearchResultDisplay>> GetMovies(string searchTerm)
        {
            var results = await SearchITunes<SearchResult>(searchTerm, "movie");

            return results.Select(x => new SearchResultDisplay {
                ResourseId = x.TrackId,
                Title = x.TrackName,
                Link = x.TrackViewUrl,
                Price = $"${x.TrackPrice}",
                DetailedDescription = new List<String> { x.LongDescription }
            }).ToList();
        }

        public async Task<List<SearchResultDisplay>> GetMusicVideos(string searchTerm)
        {
            var results = await SearchITunes<SearchResult>(searchTerm, "musicVideo");

            return results.Select(x => new SearchResultDisplay
            {
                ResourseId = x.TrackId,
                Title = $"{x.TrackName} by {x.ArtistName}",
                Link = x.TrackViewUrl,
                Price = $"${x.TrackPrice}",
                DetailedDescription = new List<string>()
            }).ToList();
        }

        public async Task<List<SearchResultDisplay>> GetSoftware(string searchTerm)
        {
            var results = await SearchITunes<SearchResult>(searchTerm, "software");

            return results.Select(x => new SearchResultDisplay
            {
                ResourseId = x.TrackId,
                Title = x.TrackName,
                Link = x.TrackViewUrl,
                Price = x.FormattedPrice,
                DetailedDescription = new List<String> {
                    x.Description,
                    //devices are returned as a list of strings in formate "devicename-devicename"
                    //null check devices since I don't know if that field is always returned
                    //then split names on the -, taking the first result and aggregating them with a comma and a space between for readability
                    x.SupportedDevices?.Aggregate("Supported Devices: ", (acc, device) => $"{acc}{device.Split('-').First()}, ") 
                }
            }).ToList();
        }

        public async Task<List<SearchResultDisplay>> GetSongs(string searchTerm)
        {
            var results = await SearchITunes<SearchResult>(searchTerm, "song");

            return results.Select(x => new SearchResultDisplay
            {
                ResourseId = x.TrackId,
                Title = $"{x.TrackName} by {x.ArtistName}",
                Link = x.TrackViewUrl,
                Price = $"${x.TrackPrice}",
                DetailedDescription = new List<string>()
            }).ToList();
        }

        public async Task<List<SearchResultDisplay>> GetTvShowsBySeason(string searchTerm)
        {
            var results = await SearchITunes<SearchResult>(searchTerm, "tvSeason");

            return results.Select(x => new SearchResultDisplay
            {
                ResourseId = x.TrackId,
                Title = x.CollectionName,
                Link = x.TrackViewUrl,
                Price = $"${x.CollectionPrice}",
                DetailedDescription = new List<String> { x.LongDescription }
            }).ToList();
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
