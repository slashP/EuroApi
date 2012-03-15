using System.Collections.ObjectModel;
using EuroApi.Models;
using Xunit;

namespace EuroApi.Tests
{
    public class TeamTest
    {
        public Team TeamWithMatches()
        {
            var team = new Team {Name = "Holland"};
            team.HomeMatches = new Collection<Match>
                               {
                                   new Match
                                       {
                                           HomeTeam = new Team {Name = team.Name},
                                           AwayTeam = new Team {Name = "Poland"},
                                           HomeTeamGoals = 0,
                                           AwayTeamGoals = 1
                                       }
                               };
            team.AwayMatches = new Collection<Match>
                                   {
                                       new Match
                                       {
                                           HomeTeam = new Team {Name = "Germany"},
                                           AwayTeam = new Team {Name = team.Name},
                                           HomeTeamGoals = 1,
                                           AwayTeamGoals = 1
                                       },
                                       new Match
                                       {
                                           HomeTeam = new Team {Name = "Ukraine"},
                                           AwayTeam = new Team {Name = team.Name},
                                           HomeTeamGoals = 1,
                                           AwayTeamGoals = 3
                                       }
                                   };
            team.Group = new Group{Name = "A"};
            return team;
        }

        [Fact]
        public void TeamHasFourPointsAfterMathces()
        {
            var team = TeamWithMatches();
            Assert.Equal(4, team.Points);
        }
        [Fact]
        public void TeamHasScoredFourGoals()
        {
            var team = TeamWithMatches();
            Assert.Equal(4, team.GoalsScored);
        }

        [Fact]
        public void TeamHasConcededThreeGoals()
        {
            var team = TeamWithMatches();
            Assert.Equal(3, team.GoalsConceded);
        }

        [Fact]
        public void TeamHasGoalDifferenceEqualToOne()
        {
            var team = TeamWithMatches();
            Assert.Equal(1, team.GoalDifference);
        }

        [Fact]
        public void AllMatchesArePlayed()
        {
            var team = TeamWithMatches();
            Assert.Equal(team.Matches, team.PlayedMatches);
        }

        [Fact]
        public void TeamWithoutHomeMatchesAlsoHasMatches()
        {
            var team = TeamWithMatches();
            team.HomeMatches = null;
            Assert.Equal(team.Matches, team.AwayMatches);
        }
    }
}
