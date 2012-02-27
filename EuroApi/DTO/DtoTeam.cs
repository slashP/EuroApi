using System;
using System.Collections.Generic;
using EuroApi.Models;

namespace EuroApi.DTO
{
    public class DtoTeam
    {
        public ICollection<DtoMatch> Matches { get; set; }
        public ICollection<DtoMatch> PlayedMatches { get; set; }

        public string Name { get; set; }
        public string GroupName { get; set; }

        public static DtoTeam TeamToDto(Team team)
        {
            return new DtoTeam
                       {
                           Name = team.Name,
                           GroupName = team.Group.Name,
                           Matches = DtoMatch.MatchesToDto(team.Matches),
                           PlayedMatches = DtoMatch.MatchesToDto(team.PlayedMatches)
                       };
        }

        public static ICollection<DtoTeam> TeamsToDto(ICollection<Team> teams)
        {
            var dtoTeams = new List<DtoTeam>();
            foreach (var team in teams)
            {
                dtoTeams.Add(DtoTeam.TeamToDto(team));
            }
            return dtoTeams;
        }
    }
}