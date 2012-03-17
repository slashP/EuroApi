namespace EuroApi.Models
{
    public class KnockoutMatchResultBet
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int MatchId { get; set; }
        public KnockoutMatch Match { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
    }
}