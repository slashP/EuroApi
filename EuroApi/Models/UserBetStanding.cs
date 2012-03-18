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
            if (resultBets == null)
                return semiFinals;
            SetupKnockoutBets(ref resultBets, KnockoutMatch.QUARTERFINAL);
            var quarterFinalBets = resultBets.Where(x => x.KnockoutMatch.Type == KnockoutMatch.QUARTERFINAL).ToList();
            semiFinals[0].HomeTeam = quarterFinalBets[0].KnockoutMatch.Winner();
            semiFinals[0].HomeTeamId = semiFinals[0].HomeTeam.Id;
            semiFinals[0].AwayTeam = quarterFinalBets[1].KnockoutMatch.Winner();
            semiFinals[0].AwayTeamId = semiFinals[0].AwayTeam.Id;
            semiFinals[1].HomeTeam = quarterFinalBets[2].KnockoutMatch.Winner();
            semiFinals[1].HomeTeamId = semiFinals[1].HomeTeam.Id;
            semiFinals[1].AwayTeam = quarterFinalBets[3].KnockoutMatch.Winner();
            semiFinals[1].AwayTeamId = semiFinals[1].AwayTeam.Id;
            return semiFinals;
        }

        public static void SetupKnockoutBets(ref List<KnockoutMatchResultBet> bets, int matchType)
        {
            foreach (var knockoutMatchResultBet in bets.Where(x => x.KnockoutMatch.Type == matchType))
            {
                knockoutMatchResultBet.SetMatchFromBet();
            }
        }

        public static List<KnockoutMatch> GetQuarterFinals(List<Team> teams, List<KnockoutMatch> quarterFinals, List<KnockoutMatchResultBet> resultBets)
        {
            if (resultBets == null)
                return quarterFinals;
            SetupKnockoutBets(ref resultBets, KnockoutMatch.QUARTERFINAL);
            quarterFinals[0].HomeTeam = teams[0];
            quarterFinals[0].HomeTeamId = teams[0].Id;
            quarterFinals[0].AwayTeam = teams[5];
            quarterFinals[0].AwayTeamId = teams[5].Id;
            quarterFinals[1].HomeTeam = teams[8];
            quarterFinals[1].HomeTeamId = teams[8].Id;
            quarterFinals[1].AwayTeam = teams[13];
            quarterFinals[1].AwayTeamId = teams[13].Id;
            quarterFinals[2].HomeTeam = teams[4];
            quarterFinals[2].HomeTeamId = teams[4].Id;
            quarterFinals[2].AwayTeam = teams[1];
            quarterFinals[2].AwayTeamId = teams[1].Id;
            quarterFinals[3].HomeTeam = teams[12];
            quarterFinals[3].HomeTeamId = teams[12].Id;
            quarterFinals[3].AwayTeam = teams[9];
            quarterFinals[3].AwayTeamId = teams[9].Id;
            return quarterFinals;
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

        public static KnockoutMatch GetFinal(List<KnockoutMatchResultBet> resultBets, KnockoutMatch final)
        {
            if (resultBets == null)
                return final;
            SetupKnockoutBets(ref resultBets, KnockoutMatch.SEMIFINAL);
            var semiFinalBets = resultBets.Where(x => x.KnockoutMatch.Type == KnockoutMatch.SEMIFINAL).ToList();
            final.HomeTeam = semiFinalBets[0].KnockoutMatch.Winner();
            final.HomeTeamId = final.HomeTeam.Id;
            final.AwayTeam = semiFinalBets[1].KnockoutMatch.Winner();
            final.AwayTeamId = final.AwayTeam.Id;
            return final;
        }
    }
}