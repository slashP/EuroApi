using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EuroApi.Models;

namespace EuroApi.Api.Controllers
{
    public class EuroApiController : ApiController
    {
        private readonly EuroApiContext _db = new EuroApiContext();

        // GET /api/EuroApi
        public IQueryable<Team> Get()
        {
            return _db.Teams;
        }

        // GET /api/EuroApi/5
        public Team Get(int id)
        {
            return _db.Teams.Find(id);
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