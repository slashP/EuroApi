using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public List<KnockoutMatch> GetQuarterFinals(List<Team> teams)
        {
            var knockoutMatches = new List<KnockoutMatch>();
            knockoutMatches.Add(new KnockoutMatch
                                    {
                                        HomeTeam = teams[0].Name,
                                        AwayTeam = teams[5].Name,
                                        Date = _matchTimes[0],
                                        Place = _places[1],
                                        Type = 1
                                    });
            knockoutMatches.Add(new KnockoutMatch
                                    {
                                        HomeTeam = teams[8].Name,
                                        AwayTeam = teams[3].Name,
                                        Date = _matchTimes[0],
                                        Place = _places[1],
                                        Type = 1
                                    });
            knockoutMatches.Add(new KnockoutMatch
                                    {
                                        HomeTeam = teams[4].Name,
                                        AwayTeam = teams[1].Name,
                                        Date = _matchTimes[0],
                                        Place = _places[1],
                                        Type = 1
                                    });
            knockoutMatches.Add(new KnockoutMatch
                                    {
                                        HomeTeam = teams[12].Name,
                                        AwayTeam = teams[9].Name,
                                        Date = _matchTimes[0],
                                        Place = _places[1],
                                        Type = 1
                                    });
            return knockoutMatches;
        }
    }
}