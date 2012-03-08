using System.Collections.Generic;
using System.Linq;

namespace EuroApi.Models
{
    public class Standing
    {
        public static List<Team> SortTeams(List<Team> teams)
        {
            var sorted = teams.OrderByDescending(x => x.Points).ThenByDescending(x => x.GoalDifference).ThenByDescending(x => x.GoalsScored).ThenBy(x => x.Name).ToList();
            return sorted;
        }

        public static List<Team> SortTeamsByGroup(List<Team> teams)
        {
            var sorted = teams.OrderBy(x => x.Group.Name).ThenByDescending(x => x.Points).ThenByDescending(x => x.GoalDifference).ThenByDescending(x => x.GoalsScored).ThenBy(x => x.Name).ToList();
            return sorted;
        }
    }
}