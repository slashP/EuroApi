using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroApi.Models
{
    public class KnockoutMatch
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Type { get; set; }

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        public string Place { get; set; }
    }
}