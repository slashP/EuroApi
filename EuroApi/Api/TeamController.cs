using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EuroApi.DAL;
using EuroApi.DTO;
using EuroApi.Models;

namespace EuroApi.Api
{
    public class TeamController : ApiController
    {
        private readonly IRepository<Team> _repository = new TeamRepository();

        // GET /api/EuroApi
        public ICollection<DtoTeam> Get()
        {
            var teams = _repository.GetAll();
            return DtoTeam.TeamsToDto(teams.ToList());
        }

        // GET /api/EuroApi/5
        public DtoTeam Get(int id)
        {
            return DtoTeam.TeamToDto(_repository.Find(id));
        }

        // GET /api/EuroApi/Germany
        public DtoTeam Get(string name)
        {
            var team = _repository.GetAll().FirstOrDefault(t => t.Name == name);
            return DtoTeam.TeamToDto(team);
        }

        // POST /api/EuroApi

        public HttpResponseMessage<Team> Post(Team team)
        {
            var added = _repository.Add(team);
            _repository.Save();
            return new HttpResponseMessage<Team>(added);
        }

        // PUT /api/EuroApi/5
        public void Put(int id, Team team)
        {
            var oldTeam = _repository.Find(id);
            oldTeam.Name = team.Name;
            _repository.Save();
        }

        // DELETE /api/EuroApi/5
        public void Delete(Team team)
        {
            _repository.Remove(team);
            _repository.Save();
        }
    }
}