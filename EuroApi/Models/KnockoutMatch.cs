using System;
using System.ComponentModel.DataAnnotations;

namespace EuroApi.Models
{
    public class KnockoutMatch
    {
        public const int QUARTERFINAL = 1;
        public const int SEMIFINAL = 2;
        public const int FINAL = 3;
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime Date { get; set; }

        public int Type { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        public string Place { get; set; }

        public Team Winner()
        {
            if (HomeTeamGoals > AwayTeamGoals)
                return HomeTeam;
            return AwayTeamGoals > HomeTeamGoals ? AwayTeam : null;
        }
    }
}