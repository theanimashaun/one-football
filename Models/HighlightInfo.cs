namespace one_football.Models
{
    public class HighlightInfo
    {
        public string Title { get; set; }
        public string Embed { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public ScoreBatCompetition Competition  { get; set; }
    }

    public class ScoreBatCompetition
    {
        public string Name { get; set; }
    }
}
