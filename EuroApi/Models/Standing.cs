using System.Collections.Generic;

namespace EuroApi.Models
{
    public class Standing
    {
        public static List<Team> SortTeams(ref List<Team> teams)
        {
            teams.Sort((t1, t2) => t1.GoalDifference.CompareTo(t2.GoalDifference));
            teams.Reverse(0, teams.Count);
            teams.Sort((t1, t2) => t1.Points.CompareTo(t2.Points));
            teams.Reverse(0, teams.Count);
            teams = CheckSameAmountOfGoals(ref teams);
            return teams;
        }

        private static List<Team> CheckSameAmountOfGoals(ref List<Team> teams)
        {
            var ts = teams;
            var changed = false;
            var count = 0;
            do
            {
                for (var i = 0; i < teams.Count - 1; i++)
                {
                    var team = teams[i];
                    var team2 = teams[i + 1];
                    if (team.Points == team2.Points &&
                        team.GoalDifference == team2.GoalDifference)
                        if (team2.GoalsScored > team.GoalsScored)
                        {
                            Swap(ref ts, ref team, ref team2);
                            changed = true;

                        }
                    count++;
                }
            } while (changed && count < 5);

            return ts;
        }


        private static void Swap(ref List<Team> teams, ref Team foo, ref Team bar)
        {
            var tmp = teams.IndexOf(bar);
            teams[teams.IndexOf(foo)] = bar;
            teams[tmp] = foo;
        }
    }
}