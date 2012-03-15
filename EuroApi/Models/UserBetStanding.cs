using System.Collections.Generic;
using System.Linq;

namespace EuroApi.Models
{
    public class UserBetStanding
    {
        public static List<Team> SortTeams(List<Team> teams, List<MatchResultBet> userBets)
        {
            var teamsWithBets = SetupBets(teams, userBets);
            return Standing.SortTeams(teamsWithBets);
        }

        public static List<Team> SortTeamsByGroup(List<Team> teams, List<MatchResultBet> userBets)
        {
            var teamsWithBets = SetupBets(teams, userBets);
            return Standing.SortTeamsByGroup(teamsWithBets);
        } 

        private static List<Team> SetupBets(List<Team> teams, List<MatchResultBet> userBets)
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
            return teams != null ? teams.ToList() : null;
        }
    }
}