﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EuroApi.Context;
using EuroApi.Models;

namespace EuroApi.DAL
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();
        public Team Find(int id)
        {
            return _db.Teams.Find(id);
        }

        public IEnumerable<Team> GetAll()
        {
            return _db.Teams.OrderBy(x => x.Id).Take(16);
        }

        public IEnumerable<Team> Query(Expression<Func<Team, bool>> filter)
        {
            return _db.Teams.OrderBy(x => x.Id).Take(16).Where(filter);
        }

        public Team Add(Team entity)
        {
            return _db.Teams.Add(entity);
        }

        public void Remove(Team entity)
        {
            _db.Teams.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}