using System;

namespace EuroApi.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }

        public DateTime Date { get; set; }

        public virtual Team HomeTeam { get; set; }
        public virtual Team GuestTeam { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        

        public void GivePointsToTeams()
        {
        }
    }
}