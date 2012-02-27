using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using EuroApi.Models;

namespace EuroApi.DTO
{
    public class DtoMatch
    {
        public string Date { get; set; }

        public string HomeTeam { get; set; }
        public string GuestTeam { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        public static DtoMatch MatchToDto(Match match)
        {
            return new DtoMatch
                       {
                           Date = match.Date.ToString(new CultureInfo("nb-NO")),
                           HomeTeam = match.HomeTeam.Name,
                           GuestTeam = match.GuestTeam.Name,
                           HomeTeamGoals = match.HomeTeamGoals,
                           AwayTeamGoals = match.AwayTeamGoals
                       };
        }

        public static ICollection<DtoMatch> MatchesToDto(ICollection<Match> matches)
        {
            var dtoMatches = new List<DtoMatch>();
            foreach (var match in matches)
            {
                dtoMatches.Add(new DtoMatch
                                   {
                                       Date = match.Date.ToString(new CultureInfo("nb-NO")),
                                       HomeTeam = match.HomeTeam.Name,
                                       GuestTeam = match.GuestTeam.Name,
                                       HomeTeamGoals = match.HomeTeamGoals,
                                       AwayTeamGoals = match.AwayTeamGoals
                                   });
            }
            return dtoMatches;
        }
    }
}