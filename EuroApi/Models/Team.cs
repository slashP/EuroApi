using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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

        [NotMapped]
        public Collection<Match> Matches 
        {
            get
            {
                if (HomeMatches == null || AwayMatches == null)
                    return null;
                return new Collection<Match>(HomeMatches.Concat(AwayMatches).ToList());
            }
        }
        [NotMapped]
        public Collection<Match> PlayedMatches
        {
            get
            {
                if (HomeMatches == null || AwayMatches == null)
                    return null;
                return new Collection<Match>(HomeMatches.Concat(AwayMatches).Where(m => m.Date.CompareTo(DateTime.Now) > 0).ToList());
            }
        }
        [NotMapped]
        public int GoalsScored
        {
            get
            {
                return HomeMatches.Sum(homeMatch => homeMatch.HomeTeamGoals ?? 0) + AwayMatches.Sum(awayMatch => awayMatch.AwayTeamGoals ?? 0);
            }
        }

        [NotMapped]
        public int GoalsConceded
        {
            get
            {
                return HomeMatches.Sum(homeMatch => homeMatch.AwayTeamGoals ?? 0) + AwayMatches.Sum(awayMatch => awayMatch.HomeTeamGoals ?? 0);
            }
        }

        [NotMapped]
        public int GoalDifference { get { return GoalsScored - GoalsConceded; } }

        [NotMapped]
        public int Points
        {
            get
            {
                var sum = 0;
                foreach (var homeMatch in HomeMatches)
                {
                    if (homeMatch.HomeTeamGoals == homeMatch.AwayTeamGoals)
                        sum += 1;
                    else if (homeMatch.HomeTeamGoals > homeMatch.AwayTeamGoals)
                        sum += 3;
                }
                foreach (var awayMatch in AwayMatches)
                {
                    if (awayMatch.HomeTeamGoals == awayMatch.AwayTeamGoals)
                        sum += 1;
                    else if (awayMatch.AwayTeamGoals > awayMatch.HomeTeamGoals)
                        sum += 3;
                }
                return sum;
            }
        }



    }
}