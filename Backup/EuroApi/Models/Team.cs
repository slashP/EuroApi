using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace EuroApi.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }

        public virtual ICollection<KnockoutMatch> KnockoutHomeMatches { get; set; }
        public virtual ICollection<KnockoutMatch> KnockoutAwayMatches { get; set; }

        [NotMapped]
        public Collection<Match> Matches
        {
            get
            {
                if (HomeMatches == null)
                {
                    HomeMatches = new Collection<Match>();
                }
                if(AwayMatches == null)
                {
                    AwayMatches = new Collection<Match>();
                }
                return new Collection<Match>(HomeMatches.Concat(AwayMatches).OrderBy(m => m.Date).ToList());
            }
            set { Debug.WriteLine("setter called  " + value); }
        }

        [NotMapped]
        public Collection<Match> PlayedMatches
        {
            get
            {
                if (HomeMatches == null)
                {
                    HomeMatches = new Collection<Match>();
                }
                if (AwayMatches == null)
                {
                    AwayMatches = new Collection<Match>();
                }
                return new Collection<Match>(HomeMatches.Concat(AwayMatches).Where(m => m.AwayTeamGoals != null && m.HomeTeamGoals != null).ToList());
            }
            set { Debug.WriteLine("setter called  " + value); }
        }

        [NotMapped]
        public int GoalsScored
        {
            get
            {
                var sum = 0;
                if (HomeMatches != null)
                {
                    sum += HomeMatches.Sum(homeMatch => homeMatch.HomeTeamGoals ?? 0);
                }
                if (AwayMatches != null)
                {
                    sum += AwayMatches.Sum(awayMatch => awayMatch.AwayTeamGoals ?? 0);
                }
                return sum;
            }
            set { Debug.WriteLine("setter called  " + value); }
        }

        [NotMapped]
        public int GoalsConceded
        {
            get
            {
                var sum = 0;
                if(HomeMatches != null)
                {
                    sum += HomeMatches.Sum(homeMatch => homeMatch.AwayTeamGoals ?? 0);
                }
                if(AwayMatches != null)
                {
                    sum += AwayMatches.Sum(awayMatch => awayMatch.HomeTeamGoals ?? 0);
                }
                return sum;
            }
            set { Debug.WriteLine("setter called  " + value); }
        }

        [NotMapped]
        public int GoalDifference { get { return GoalsScored - GoalsConceded; } }

        [NotMapped]
        public int Points
        {
            get
            {
                var sum = 0;
                if (HomeMatches != null)
                {
                    foreach (var homeMatch in HomeMatches.Where(homeMatch => homeMatch.HomeTeamGoals != null))
                    {
                        if (homeMatch.HomeTeamGoals == homeMatch.AwayTeamGoals)
                            sum += 1;
                        else if (homeMatch.HomeTeamGoals > homeMatch.AwayTeamGoals)
                            sum += 3;
                    }
                }
                if (AwayMatches != null)
                {
                    foreach (var awayMatch in AwayMatches.Where(awayMatch => awayMatch.HomeTeamGoals != null))
                    {
                        if (awayMatch.HomeTeamGoals == awayMatch.AwayTeamGoals)
                            sum += 1;
                        else if (awayMatch.AwayTeamGoals > awayMatch.HomeTeamGoals)
                            sum += 3;
                    }
                }
                return sum;
            }
            set { Debug.WriteLine("setter called  " + value); }
        }



    }
}