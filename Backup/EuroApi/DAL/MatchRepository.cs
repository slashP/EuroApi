using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EuroApi.Context;
using EuroApi.Models;

namespace EuroApi.DAL
{
    public class MatchRepository : IRepository<Match>
    {
        private FootyFeudContext _db = new FootyFeudContext();

        public Match Find(int id)
        {
            return _db.Matches.Find(id);
        }

        public IEnumerable<Match> GetAll()
        {
            return _db.Matches;
        }

        public IEnumerable<Match> Query(Expression<Func<Match, bool>> filter)
        {
            return _db.Matches.Where(filter).OrderBy(x => x.Date);
        }

        public Match Add(Match entity)
        {
            return _db.Matches.Add(entity);
        }

        public void Remove(Match entity)
        {
            _db.Matches.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}