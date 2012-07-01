using System.Collections.Generic;

namespace EuroApi.Models
{
    public class TournamentBet
    {
        public List<TeamBet> TeamBets { get; set; }
        public List<PlayerBet> PlayerBets { get; set; }
    }
}