
namespace EuroApi.Models
{
    public class MatchResultBet
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
    }
}