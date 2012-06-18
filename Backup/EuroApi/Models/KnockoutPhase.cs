using System.Collections.Generic;
using System.Linq;
using EuroApi.DAL;

namespace EuroApi.Models
{
    public class KnockoutPhase
    {
        public List<KnockoutMatch> KnockoutMatches { get; set; }

        private readonly IRepository<KnockoutMatch> _knockoutMatchRepsoitory = new KnockoutMatchRepository();
        private readonly IRepository<KnockoutMatchResultBet> _knockoutBetRepository = new KnockoutMatchResultBetRepository();

        public List<KnockoutMatch> SemiFinals(List<KnockoutMatch> quarterFinals)
        {
            var semiFinals = _knockoutMatchRepsoitory.Query(x => x.Type == KnockoutMatch.SEMIFINAL).ToList();
            semiFinals[0].HomeTeam = quarterFinals[0].Winner();
            semiFinals[0].AwayTeam = quarterFinals[2].Winner();
            semiFinals[1].HomeTeam = quarterFinals[1].Winner();
            semiFinals[1].AwayTeam = quarterFinals[3].Winner();
            return semiFinals;
        }

        public KnockoutMatch Final(List<KnockoutMatch> semiFinals)
        {
            var final = _knockoutMatchRepsoitory.Query(x => x.Type == KnockoutMatch.FINAL).FirstOrDefault();
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