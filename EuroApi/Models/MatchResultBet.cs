
namespace EuroApi.Models
{
    public class MatchResultBet
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        private bool IsCorrectBet()
        {
            return MatchIsPlayed() && Match.HomeTeamGoals == HomeTeamGoals && Match.AwayTeamGoals == AwayTeamGoals;
        }

        private bool IsCorrectOutcome()
        {
            return MatchIsPlayed() && ((HomeTeamGoals > AwayTeamGoals && Match.HomeTeamGoals > Match.AwayTeamGoals)
                   || (HomeTeamGoals < AwayTeamGoals && Match.HomeTeamGoals < Match.AwayTeamGoals)
                   || (HomeTeamGoals == AwayTeamGoals) && (Match.HomeTeamGoals == Match.AwayTeamGoals));
        }

        private bool MatchIsPlayed()
        {
            return Match.HomeTeamGoals != null && Match.AwayTeamGoals != null;
        }

        public int CorrectOutcome()
        {
            return IsCorrectOutcome() ? 1 : 0;
        }

        public int CorrectBet()
        {
            return IsCorrectBet() ? 1 : 0;
        }
    }
}