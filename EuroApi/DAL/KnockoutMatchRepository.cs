using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EuroApi.Models;

namespace EuroApi.DAL
{
    public class KnockoutMatchRepository : IRepository<KnockoutMatch>
    {
        private EuroApiContext _db = new EuroApiContext();

        public KnockoutMatch Find(int id)
        {

            return _db.KnockoutMatches.Find(id);
        }

        public IEnumerable<KnockoutMatch> GetAll()
        {
            return _db.KnockoutMatches;
        }

        public IEnumerable<KnockoutMatch> Query(Expression<Func<KnockoutMatch, bool>> filter)
        {
            return _db.KnockoutMatches.Where(filter).OrderBy(x => x.Date);
        }

        public KnockoutMatch Add(KnockoutMatch entity)
        {
            return _db.KnockoutMatches.Add(entity);
        }

        public void Remove(KnockoutMatch entity)
        {
            _db.KnockoutMatches.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}