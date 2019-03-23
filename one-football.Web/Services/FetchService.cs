using Newtonsoft.Json;
using one_football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace one_football.Services
{
    public class FetchService : IFetchService
    {
        private readonly string _apiFootballUrl;
        private readonly string _scoreBatUrl;
        private readonly IBaseService _baseService;

        public FetchService(IConfiguration configuration, IBaseService baseService)
        {
            _apiFootballUrl = configuration["ApiEndpoints:ApiFootballUrl"];
            _scoreBatUrl = configuration["ApiEndpoints:ScoreBatUrl"];
            _baseService = baseService;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var client = _baseService.SetupHttpClient(_apiFootballUrl);
            var url = $"{_apiFootballUrl}get_countries";
            var response = await client.GetAsync(url);

            var responseMessage = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage);
            }

            return JsonConvert.DeserializeObject<IEnumerable<Country>>(responseMessage);
        }

        public async Task<IEnumerable<Competition>> GetCompetitions(int countryId = 0)
        {
            var client = _baseService.SetupHttpClient(_apiFootballUrl);
            var url = $"{_apiFootballUrl}get_leagues{(countryId > 0 ? "&country_id=" + countryId : "")}";
            var response = await client.GetAsync(url);

            var responseMessage = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage);
            }

            return JsonConvert.DeserializeObject<IEnumerable<Competition>>(responseMessage);
        }

        public async Task<IEnumerable<StandingInfo>> GetStandings(int leagueId)
        {
            var client = _baseService.SetupHttpClient(_apiFootballUrl);
            var url = $"{_apiFootballUrl}get_standings&league_id={leagueId}";
            var response = await client.GetAsync(url);

            var responseMessage = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage);
            }

            return JsonConvert.DeserializeObject<IEnumerable<StandingInfo>>(responseMessage);
        }

        public async Task<IEnumerable<LivescoreInfo>> GetLiveScores()
        {
            var currentDate = DateTime.Now;
            var daysBefore = currentDate.Subtract(TimeSpan.FromDays(15));

            // Results with match_live = 1 are ongoing matches
            var client = _baseService.SetupHttpClient(_apiFootballUrl);
            var url = $"{_apiFootballUrl}get_events&from={daysBefore:yyyy-MM-dd}&to={currentDate:yyyy-MM-dd}";
            var response = await client.GetAsync(url);

            var responseMessage = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage);
            }

            var livescores = JsonConvert.DeserializeObject<List<LivescoreInfo>>(responseMessage);
            if (livescores.Count(x => x.IsLive == "1") > 5)
            {
                return livescores.Where((x => x.IsLive == "1"));
            }
            return livescores;
        }

        public async Task<IEnumerable<HighlightInfo>> GetVideoHighlights()
        {
            var client = _baseService.SetupHttpClient(_scoreBatUrl);
            var response = await client.GetAsync("");

            var responseMessage = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage);
            }

            var highlights = JsonConvert.DeserializeObject<List<HighlightInfo>>(responseMessage);
            
            return highlights.Take(50);
        }

       
    }
}
