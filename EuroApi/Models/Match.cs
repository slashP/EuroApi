using System;

namespace EuroApi.Models
{
    public class Match
    {
        public const int GROUP_MATCH = 0;
        public const int QUARTERFINAL = 1;
        public const int SEMIFINAL = 2;
        public const int FINAL = 3;
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }

        public DateTime Date { get; set; }

        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        public string Place { get; set; }

        public int Type { get; set; }

        public Team Winner()
        {
            if (HomeTeamGoals > AwayTeamGoals)
                return HomeTeam;
            return AwayTeamGoals > HomeTeamGoals ? AwayTeam : null;
        }
    }
}