using Newtonsoft.Json;

namespace one_football.Models
{
    public class Competition
    {
        [JsonProperty("country_id")]
        public int CountryId { get; set; }
        [JsonProperty("country_name")]
        public string CountryName { get; set; }
        [JsonProperty("league_id")]
        public int LeagueId { get; set; }
        [JsonProperty("league_name")]
        public string LeagueName { get; set; }
    }
}
