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
    }
}