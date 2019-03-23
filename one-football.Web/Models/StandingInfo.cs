using Newtonsoft.Json;

namespace one_football.Models
{
    public class StandingInfo
    {
        [JsonProperty("country_name")]
        public string CountryName { get; set; }
        [JsonProperty("league_id")]
        public int LeagueId { get; set; }
        [JsonProperty("league_name")]
        public string LeagueName { get; set; }
        [JsonProperty("team_name")]
        public string TeamName { get; set; }
        [JsonProperty("overall_league_position")]
        public int LeaguePosition { get; set; }
        [JsonProperty("overall_league_payed")]
        public int MatchesPlayed { get; set; }
        [JsonProperty("overall_league_W")]
        public int MatchesWon { get; set; }
        [JsonProperty("overall_league_D")]
        public int MatchesDrawn { get; set; }
        [JsonProperty("overall_league_L")]
        public int MatchesLost { get; set; }
        [JsonProperty("overall_league_GF")]
        public int GoalsFor { get; set; }
        [JsonProperty("overall_league_GA")]
        public int GoalsAgainst { get; set; }
        [JsonProperty("overall_league_PTS")]
        public int Points { get; set; }
    }

}
