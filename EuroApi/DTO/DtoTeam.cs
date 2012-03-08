using System;
using System.Collections.Generic;
using System.Linq;
using EuroApi.Models;

namespace EuroApi.DTO
{
    public class DtoTeam
    {
        public ICollection<DtoMatch> Matches { get; set; }
        public ICollection<DtoMatch> PlayedMatches { get; set; }

        public string Name { get; set; }
        public string GroupName { get; set; }
        public int GoalsScored { get; set; }
        public int Points { get; set; }
        public int GoalsConceded { get; set; }
        public int GoalDifference { get; set; }
        public int MatchCount { get; set; }
        public string Group { get; set; }

        public static DtoTeam TeamToDto(Team team)
        {
            var dto = new DtoTeam
                       {
                           Name = team.Name,
                           GroupName = team.Group.Name,
                           Matches = DtoMatch.MatchesToDto(team.Matches),
                           PlayedMatches = DtoMatch.MatchesToDto(team.PlayedMatches),
                           Points = team.Points,
                           GoalsConceded = team.GoalsConceded,
                           GoalsScored = team.GoalsScored,
                           GoalDifference = team.GoalDifference,
                           Group = team.Group.Name
                       };
            dto.MatchCount = team.Matches.Count(x => x.HomeTeamGoals != null);
            return dto;
        }

        public static ICollection<DtoTeam> TeamsToDto(ICollection<Team> teams)
        {
            return teams.Select(TeamToDto).ToList();
        }
    }
}