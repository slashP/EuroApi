using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EuroApi.Models;

namespace EuroApi.DAL
{
    public class KnockoutMatchResultBetRepository : IRepository<KnockoutMatchResultBet>
    {
        private readonly EuroApiContext _db = new EuroApiContext();
        public KnockoutMatchResultBet Find(int id)
        {
            return _db.KnockoutMatchResultBets.Find(id);
        }

        public IEnumerable<KnockoutMatchResultBet> GetAll()
        {
            return _db.KnockoutMatchResultBets;
        }

        public IEnumerable<KnockoutMatchResultBet> Query(Expression<Func<KnockoutMatchResultBet, bool>> filter)
        {
            return _db.KnockoutMatchResultBets.Where(filter);
        }

        public KnockoutMatchResultBet Add(KnockoutMatchResultBet entity)
        {
            return _db.KnockoutMatchResultBets.Add(entity);            
        }

        public void Remove(KnockoutMatchResultBet entity)
        {
            _db.KnockoutMatchResultBets.Remove(entity);            
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}