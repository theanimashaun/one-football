using Microsoft.AspNetCore.Mvc;
using one_football.Models;
using one_football.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace one_football.Controllers
{
    [Route("api/fetch")]
    [ApiController]
    public class FetchController : Controller
    {
        private readonly IFetchService _fetchService;

        public FetchController(IFetchService fetchService)
        {
            _fetchService = fetchService;
        }

        [HttpGet("GetCountries")]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            var result = await _fetchService.GetCountries();
            return result;
        }

        [HttpGet("GetCompetitions/{countryId}")]
        public async Task<IEnumerable<Competition>> GetCompetitions(int countryId = 0)
        {
            var result = await _fetchService.GetCompetitions(countryId);
            return result;
        }

        [HttpGet("GetCompetitions/{leagueId}")]
        public async Task<IEnumerable<StandingInfo>> GetStandings(int leagueId = 0)
        {
            var result = await _fetchService.GetStandings(leagueId);
            return result;
        }

        [HttpGet("GetLiveScores")]
        public async Task<IEnumerable<LivescoreInfo>> GetLiveScores()
        {
            var result = await _fetchService.GetLiveScores();
            return result;
        }


        [HttpGet("GetVideoHighlights")]
        public async Task<IEnumerable<HighlightInfo>> GetVideoHighlights()
        {
            var result = await _fetchService.GetVideoHighlights();
            return result;
        }
    }
}