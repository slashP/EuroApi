using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EuroApi.Models;
using Xunit;

namespace EuroApi.Tests
{
    public class KnockoutMatchTest
    {
        [Fact]
        public void GivenTheResultIsOneOneThenNoOneIsTheWinner()
        {
            var match = new KnockoutMatch
            {
                HomeTeam = new Team { Name = "Holland" },
                AwayTeam = new Team { Name = "Germany" },
                HomeTeamGoals = 1,
                AwayTeamGoals = 1
            };
            Assert.Equal(null, match.Winner());
        }

        [Fact]
        public void GivenTheResultIsOneZeroThenTheHomeTeamIsTheWinner()
        {
            var match = new KnockoutMatch()
            {
                HomeTeam = new Team { Name = "Holland" },
                AwayTeam = new Team { Name = "Germany" },
                HomeTeamGoals = 1,
                AwayTeamGoals = 0
            };
            Assert.Equal(match.HomeTeam, match.Winner());
        }

        [Fact]
        public void GivenTheResultIsZeroOneThenTheAwayTeamIsTheWinner()
        {
            var match = new KnockoutMatch
            {
                HomeTeam = new Team { Name = "Holland" },
                AwayTeam = new Team { Name = "Germany" },
                HomeTeamGoals = 0,
                AwayTeamGoals = 1
            };
            Assert.Equal(match.AwayTeam, match.Winner());
        }
    }
}
