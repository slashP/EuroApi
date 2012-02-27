using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EuroApi.DTO;
using EuroApi.Models;
using System.Data.Entity;

namespace EuroApi.Api.Controllers
{
    public class TeamController : ApiController
    {
        private EuroApiContext _db = new EuroApiContext();

        // GET /api/EuroApi
        public ICollection<DtoTeam> Get()
        {
            var teams = _db.Teams;
            return DtoTeam.TeamsToDto(teams.ToList());
        }

        // GET /api/EuroApi/5
        public DtoTeam Get(int id)
        {
            return DtoTeam.TeamToDto(_db.Teams.Find(id));
        }

        // GET /api/EuroApi/Germany
        public DtoTeam Get(string name)
        {
            var team = _db.Teams.FirstOrDefault(t => t.Name == name);
            return DtoTeam.TeamToDto(team);
        }

        // POST /api/EuroApi

        public HttpResponseMessage<Team> Post(Team team)
        {
            var added = _db.Teams.Add(team);
            _db.SaveChanges();
            return new HttpResponseMessage<Team>(added);
        }

        // PUT /api/EuroApi/5
        public void Put(int id, Team team)
        {
            var oldTeam = _db.Teams.Find(id);
            oldTeam.Name = team.Name;
            _db.SaveChanges();
        }

        // DELETE /api/EuroApi/5
        public void Delete(Team team)
        {
            _db.Teams.Remove(team);
            _db.SaveChanges();
        }
    }
}