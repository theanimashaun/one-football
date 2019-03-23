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
            return await _fetchService.GetCountries();
        }

        [HttpGet("GetCompetitions")]
        public async Task<IEnumerable<Competition>> GetCompetitions(int countryId = 0)
        {
            return await _fetchService.GetCompetitions(countryId);
        }

        [HttpGet("GetStandings/{leagueId}")]
        public async Task<IEnumerable<StandingInfo>> GetStandings(int leagueId)
        {
            if (leagueId < 1)
            {
                return new List<StandingInfo>();
            }
            return await _fetchService.GetStandings(leagueId);
        }

        [HttpGet("GetLiveScores")]
        public async Task<IEnumerable<LivescoreInfo>> GetLiveScores()
        {
            return await _fetchService.GetLiveScores();
        }


        [HttpGet("GetVideoHighlights")]
        public async Task<IEnumerable<HighlightInfo>> GetVideoHighlights()
        {
            return await _fetchService.GetVideoHighlights();
        }
    }
}