using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EuroApi.Models;

namespace EuroApi.DAL
{
    public class PlayerBetRepository : IRepository<PlayerBet>
    {
        private readonly EuroApiContext _db = new EuroApiContext();

        public PlayerBet Find(int id)
        {
            return _db.PlayerBets.Find(id);
        }

        public IEnumerable<PlayerBet> GetAll()
        {
            return _db.PlayerBets;
        }

        public IEnumerable<PlayerBet> Query(Expression<Func<PlayerBet, bool>> filter)
        {
            return _db.PlayerBets.Where(filter);
        }

        public PlayerBet Add(PlayerBet entity)
        {
            return _db.PlayerBets.Add(entity);
        }

        public void Remove(PlayerBet entity)
        {
            _db.PlayerBets.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}