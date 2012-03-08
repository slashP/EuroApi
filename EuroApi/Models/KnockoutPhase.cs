﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EuroApi.DAL;

namespace EuroApi.Models
{
    public class KnockoutPhase
    {
        public List<KnockoutMatch> KnockoutMatches { get; set; }

        private readonly List<DateTime> _matchTimes = new List<DateTime>
                                                {
                                                    DateTime.Parse("21 June 2012 20:45"),
                                                    DateTime.Parse("22 June 2012 20:45"),
                                                    DateTime.Parse("23 June 2012 20:45"),
                                                    DateTime.Parse("24 June 2012 20:45"),
                                                    DateTime.Parse("27 June 2012 20:45"),
                                                    DateTime.Parse("28 June 2012 20:45"),
                                                    DateTime.Parse("1 July 2012 20:45")
                                                };
        private readonly List<string> _places = new List<string>{"Warzaw", "Donetsk", "Gdansk", "Kiev"}; 
        private readonly IRepository<Match> _matchRepsoitory = new MatchRepository(); 
        public List<Match> GetQuarterFinals(List<Team> teams)
        {
            var quarterFinals = _matchRepsoitory.Query(x => x.Type == Match.QUARTERFINAL).ToList();
            quarterFinals[0].HomeTeam = teams[0];
            quarterFinals[0].AwayTeam = teams[5];
            quarterFinals[1].HomeTeam = teams[8];
            quarterFinals[1].AwayTeam = teams[13];
            quarterFinals[2].HomeTeam = teams[4];
            quarterFinals[2].AwayTeam = teams[1];
            quarterFinals[3].HomeTeam = teams[12];
            quarterFinals[3].AwayTeam = teams[9];
            return quarterFinals;
        }

        public List<Match> SemiFinals(List<Match> quarterFinals)
        {
            var semiFinals = _matchRepsoitory.Query(x => x.Type == Match.SEMIFINAL).ToList();
            semiFinals[0].HomeTeam = quarterFinals[0].Winner();
            semiFinals[0].AwayTeam = quarterFinals[2].Winner();
            semiFinals[1].HomeTeam = quarterFinals[1].Winner();
            semiFinals[1].AwayTeam = quarterFinals[3].Winner();
            return semiFinals;
        }

        public Match Final(List<Match> semiFinals)
        {
            var final = _matchRepsoitory.Query(x => x.Type == Match.FINAL).FirstOrDefault();
            if (final == null)
            {
                return null;
            }
            final.HomeTeam = semiFinals[0].Winner();
            final.AwayTeam = semiFinals[1].Winner();
            return final;
        } 
    }
}