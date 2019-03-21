using Newtonsoft.Json;
using one_football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace one_football.Services
{
    public class FetchService : BaseService, IFetchService
    {
        private readonly string _apiFootballUrl;
        private readonly string _scoreBatUrl;

        public FetchService(IConfiguration configuration)
        {
            _apiFootballUrl = configuration["ApiEndpoints:ApiFootballUrl"];
            _scoreBatUrl = configuration["ApiEndpoints:ScoreBatUrl"];
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var client = SetupHttpClient(_apiFootballUrl);
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
            var client = SetupHttpClient(_apiFootballUrl);
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
            var client = SetupHttpClient(_apiFootballUrl);
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
            var aDayBefore = currentDate.Subtract(TimeSpan.FromDays(1));

            // Results with match_live = 1 are ongoing matches
            var client = SetupHttpClient(_apiFootballUrl);
            var url = $"{_apiFootballUrl}get_events&from={currentDate:yyyy-MM-dd}&{aDayBefore:yyyy-MM-dd}";
            var response = await client.GetAsync(url);

            var responseMessage = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage);
            }

            var livescores = JsonConvert.DeserializeObject<List<LivescoreInfo>>(responseMessage);
            if (livescores.Count(x => x.IsLive) > 5)
            {
                return livescores.Where((x => x.IsLive));
            }
            return livescores;
        }

        public async Task<IEnumerable<HighlightInfo>> GetVideoHighlights()
        {
            var client = SetupHttpClient(_scoreBatUrl);
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
