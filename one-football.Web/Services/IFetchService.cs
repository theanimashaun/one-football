using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using one_football.Models;

namespace one_football.Services
{
    public interface IFetchService
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<Competition>> GetCompetitions(int countryId = 0);
        Task<IEnumerable<StandingInfo>> GetStandings(int leagueId);
        Task<IEnumerable<LivescoreInfo>> GetLiveScores();
        Task<IEnumerable<HighlightInfo>> GetVideoHighlights();
    }
}