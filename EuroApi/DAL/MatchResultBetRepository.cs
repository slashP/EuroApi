using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EuroApi.Models;

namespace EuroApi.DAL
{
    public class MatchResultBetRepository : IRepository<MatchResultBet>
    {
        private readonly EuroApiContext _db = new EuroApiContext();

        public MatchResultBet Find(int id)
        {
            return _db.MatchResultBets.Find(id);
        }

        public IEnumerable<MatchResultBet> GetAll()
        {
            return _db.MatchResultBets;
        }

        public IEnumerable<MatchResultBet> Query(Expression<Func<MatchResultBet, bool>> filter)
        {
            return _db.MatchResultBets.Where(filter);
        }

        public MatchResultBet Add(MatchResultBet entity)
        {
            return _db.MatchResultBets.Add(entity);
        }

        public void Remove(MatchResultBet entity)
        {
            _db.MatchResultBets.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}