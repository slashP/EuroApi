using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EuroApi.Context;
using EuroApi.Models;

namespace EuroApi.DAL
{
    public class PlayerBetTypeRepository : IRepository<PlayerBetType>
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();
        public PlayerBetType Find(int id)
        {
            return _db.PlayerBetTypes.Find(id);
        }

        public IEnumerable<PlayerBetType> GetAll()
        {
            return _db.PlayerBetTypes;
        }

        public IEnumerable<PlayerBetType> Query(Expression<Func<PlayerBetType, bool>> filter)
        {
            return _db.PlayerBetTypes.Where(filter);
        }

        public PlayerBetType Add(PlayerBetType entity)
        {
            return _db.PlayerBetTypes.Add(entity);
        }

        public void Remove(PlayerBetType entity)
        {
            _db.PlayerBetTypes.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}