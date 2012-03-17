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

        public static List<KnockoutMatch> GetSemiFinals(List<KnockoutMatchResultBet> resultBets, List<KnockoutMatch> quarterFinals, List<KnockoutMatch> semiFinals)
        {
            var bets = resultBets.OrderBy(x => x.Id).ToList();

            return new List<KnockoutMatch>{
                new KnockoutMatch
                        {
                            HomeTeam = bets[0].Match.Winner(),
                            HomeTeamId = bets[0].Match.Winner().Id,
                            AwayTeam = bets[2].Match.Winner(),
                            AwayTeamId = bets[2].Match.Winner().Id,
                            Type = KnockoutMatch.SEMIFINAL
                        },
                
                           new KnockoutMatch
                               {
                                   HomeTeam = bets[1].Match.Winner(),
                                   HomeTeamId = bets[1].Match.Winner().Id,
                                   AwayTeam = bets[3].Match.Winner(),
                                   AwayTeamId = bets[3].Match.Winner().Id,
                                   Type = KnockoutMatch.SEMIFINAL
                               }
                       };

        }

        public static KnockoutMatch GetFinal(List<KnockoutMatchResultBet> resultBets)
        {
            var bets = resultBets.Where(x => x.Match.Type == KnockoutMatch.QUARTERFINAL).OrderBy(x => x.Id).ToList();
            return new KnockoutMatch
                       {
                           HomeTeam = bets[0].Match.Winner(),
                           HomeTeamId = bets[0].Match.Winner().Id,
                           AwayTeam = bets[1].Match.Winner(),
                           AwayTeamId = bets[1].Match.Winner().Id,
                           Type = KnockoutMatch.FINAL
                       };
        }

        private static List<Team> SetupBets(IEnumerable<Team> teams, List<MatchResultBet> userBets)
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