using Newtonsoft.Json;

namespace one_football.Models
{
    public class LivescoreInfo
    {
        [JsonProperty("match_id")]
        public int MatchId { get; set; }
        [JsonProperty("country_name")]
        public string CountryName { get; set; }
        [JsonProperty("league_name")]
        public string LeagueName { get; set; }
        [JsonProperty("match_date")]
        public string MatchDate { get; set; }
        [JsonProperty("match_status")]
        public string MatchStatus { get; set; }
        [JsonProperty("match_time")]
        public string MatchTime { get; set; }
        [JsonProperty("match_hometeam_name")]
        public string HomeTeam { get; set; }
        [JsonProperty("match_hometeam_score")]
        public string HomeTeamScore { get; set; }
        [JsonProperty("match_awayteam_name")]
        public string AwayTeam { get; set; }
        [JsonProperty("match_awayteam_score")]
        public string AwayTeamScore { get; set; }
        [JsonProperty("match_live")]
        public string IsLive { get; set; }
        [JsonProperty("goalscorer")]
        public GoalScorer[] GoalScorers { get; set; }

        public LivescoreInfo()
        {
            GoalScorers = new GoalScorer[]{};
        }
    }

    public class GoalScorer
    {
        [JsonProperty("time")]
        public string GoalTime { get; set; }
        [JsonProperty("home_scorer")]
        public string HomeScorer { get; set; }
        [JsonProperty("score")]
        public string Score { get; set; }
        [JsonProperty("away_scorer")]
        public string AwayScorer { get; set; }
    }
}
