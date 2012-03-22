using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EuroApi.Models;

namespace EuroApi.DAL
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly EuroApiContext _db = new EuroApiContext();
        public Player Find(int id)
        {
            return _db.Players.Find(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _db.Players;
        }

        public IEnumerable<Player> Query(Expression<Func<Player, bool>> filter)
        {
            return _db.Players.Where(filter);
        }

        public Player Add(Player entity)
        {
            return _db.Players.Add(entity);
        }

        public void Remove(Player entity)
        {
            _db.Players.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}