using EuroApi.DAL;

namespace EuroApi.Models
{
    public class KnockoutMatchResultBet
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int KnockoutMatchId { get; set; }
        public virtual KnockoutMatch KnockoutMatch { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }


        public void SetMatchFromBet()
        {
            var teamRepository = new TeamRepository();
            KnockoutMatch.HomeTeamId = HomeTeamId;
            KnockoutMatch.AwayTeamId = AwayTeamId;
            KnockoutMatch.HomeTeam = teamRepository.Find(HomeTeamId);
            KnockoutMatch.AwayTeam = teamRepository.Find(AwayTeamId);
            KnockoutMatch.HomeTeamGoals = HomeTeamGoals;
            KnockoutMatch.AwayTeamGoals = AwayTeamGoals;
        }

        private bool IsCorrectBet()
        {
            return MatchIsPlayed() && KnockoutMatch.HomeTeamGoals == HomeTeamGoals && KnockoutMatch.AwayTeamGoals == AwayTeamGoals;
        }

        private bool IsCorrectOutcome()
        {
            return MatchIsPlayed() && ((HomeTeamGoals > AwayTeamGoals && KnockoutMatch.HomeTeamGoals > KnockoutMatch.AwayTeamGoals)
                   || (HomeTeamGoals < AwayTeamGoals && KnockoutMatch.HomeTeamGoals < KnockoutMatch.AwayTeamGoals)
                   || (HomeTeamGoals == AwayTeamGoals) && (KnockoutMatch.HomeTeamGoals == KnockoutMatch.AwayTeamGoals));
        }

        private bool MatchIsPlayed()
        {
            return KnockoutMatch.HomeTeamGoals != null && KnockoutMatch.AwayTeamGoals != null;
        }

        public int CorrectOutcome()
        {
            return IsCorrectOutcome() ? 1 : 0;
        }

        public int CorrectBet()
        {
            return IsCorrectBet() ? 1 : 0;
        }

        public int Points()
        {
            return 2 * CorrectOutcome() + CorrectBet();
        }
    }
}