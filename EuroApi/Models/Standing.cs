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
    }
}