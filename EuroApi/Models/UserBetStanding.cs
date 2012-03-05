using System.Collections.Generic;
using System.Linq;

namespace EuroApi.Models
{
    public class UserBetStanding
    {
        public static List<Team> SortTeams(List<Team> teams, List<MatchResultBet> userBets)
        {
            SetupBets(ref teams, userBets);
            return Standing.SortTeams(teams);

        }

        private static void SetupBets(ref List<Team> teams, List<MatchResultBet> userBets)
        {
            foreach (var match in teams.SelectMany(x => x.Matches).Distinct())
            {
                var userBet = userBets.FirstOrDefault(x => x.MatchId == match.Id);
                if(userBet == null)
                {
                    match.HomeTeamGoals = null;
                    match.AwayTeamGoals = null;
                    continue;
                }
                match.HomeTeamGoals = userBet.HomeTeamGoals;
                match.AwayTeamGoals = userBet.AwayTeamGoals;
            }
        }
    }
}