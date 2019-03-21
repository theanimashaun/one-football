using Newtonsoft.Json;

namespace one_football.Models
{
    public class Country
    {
        [JsonProperty("country_id")]
        public int Id { get; set; }
        [JsonProperty("country_name")]
        public string Name { get; set; }
    }
}
