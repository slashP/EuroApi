using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EuroApi.DAL;
using EuroApi.DTO;
using EuroApi.Models;

namespace EuroApi.Api
{
    public class MatchBetController : ApiController
    {
        private readonly IRepository<MatchResultBet> _repository = new MatchResultBetRepository();

        public ICollection<MatchResultBet> Get()
        {
            var bets = _repository.GetAll();
            return bets.ToList();
        }
    }
}