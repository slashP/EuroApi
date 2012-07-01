using System;

namespace EuroApi.Models
{
    public class TeamBet : IComparable<TeamBet>
    {
        public int Id { get; set; }
        public int TeamBetTypeId { get; set; }
        public virtual TeamBetType PlayerBetType { get; set; }
        public string User { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int CompareTo(TeamBet other)
        {
            return TeamId.CompareTo(other.TeamId);
        }
    }
}