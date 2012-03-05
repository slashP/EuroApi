using EuroApi.Models;

namespace EuroApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EuroApi.Models.EuroApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EuroApi.Models.EuroApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Groups.Add(new Group {Id = 1, Name = "A"});
            context.Groups.Add(new Group {Id = 2, Name = "B"});
            context.Groups.Add(new Group {Id = 3, Name = "C"});
            context.Groups.Add(new Group {Id = 4, Name = "D"});
            context.Teams.Add(new Team {Id = 1, GroupId = 1, Name = "Poland"});
            context.Teams.Add(new Team { Id = 2, GroupId = 1, Name = "Greece" });
            context.Teams.Add(new Team { Id = 3, GroupId = 1, Name = "Russia"});
            context.Teams.Add(new Team { Id = 4, GroupId = 1, Name = "Czech" });
            context.Teams.Add(new Team { Id = 5, GroupId = 2, Name = "Netherlands"});
            context.Teams.Add(new Team { Id = 6, GroupId = 2, Name = "Denmark"});
            context.Teams.Add(new Team { Id = 7, GroupId = 2, Name = "Germany" });
            context.Teams.Add(new Team { Id = 8, GroupId = 2, Name = "Portugal"});
            context.Teams.Add(new Team { Id = 9, GroupId = 3, Name = "Spain" });
            context.Teams.Add(new Team { Id = 10, GroupId = 3, Name = "Italy"});
            context.Teams.Add(new Team { Id = 11, GroupId = 3, Name = "Ireland"});
            context.Teams.Add(new Team { Id = 12, GroupId = 3, Name = "Croatia"});
            context.Teams.Add(new Team { Id = 13, GroupId = 4, Name = "France" });
            context.Teams.Add(new Team { Id = 14, GroupId = 4, Name = "England"});
            context.Teams.Add(new Team { Id = 15, GroupId = 4, Name = "Ukraine"});
            context.Teams.Add(new Team { Id = 16, GroupId = 4, Name = "Sweden" });
context.Matches.Add(new Match{Id = 1, Date = DateTime.Parse("June 8,2012 18:00"), HomeTeamId = 1, GuestTeamId = 2, Place = "Warsaw"});
context.Matches.Add(new Match{Id = 2, Date = DateTime.Parse("June 8,2012 20:45"), HomeTeamId = 3, GuestTeamId = 4, Place = "Wroclaw"});
context.Matches.Add(new Match{Id = 3, Date = DateTime.Parse("June 9,2012 18:00"), HomeTeamId = 5, GuestTeamId = 6, Place = "Kharkov"});
context.Matches.Add(new Match{Id = 4, Date = DateTime.Parse("June 9,2012 20:45"), HomeTeamId = 7, GuestTeamId = 8, Place = "Lvov"});
context.Matches.Add(new Match{Id = 5, Date = DateTime.Parse("June 10,2012 18:00"), HomeTeamId = 9, GuestTeamId = 10, Place = "Gdansk"});
context.Matches.Add(new Match{Id = 6, Date = DateTime.Parse("June 10,2012 20:45"), HomeTeamId = 11, GuestTeamId = 12, Place = "Poznan"});
context.Matches.Add(new Match{Id = 7, Date = DateTime.Parse("June 11,2012 18:00"), HomeTeamId = 13, GuestTeamId = 14, Place = "Donetsk"});
context.Matches.Add(new Match{Id = 8, Date = DateTime.Parse("June 11,2012 20:45"), HomeTeamId = 15, GuestTeamId = 16, Place = "Kiev"});
context.Matches.Add(new Match{Id = 9, Date = DateTime.Parse("June 12,2012 18:00"), HomeTeamId = 2, GuestTeamId = 4, Place = "Wroclaw"});
context.Matches.Add(new Match{Id = 10, Date = DateTime.Parse("June 12,2012 20:45"), HomeTeamId = 1, GuestTeamId = 3, Place = "Warsaw"});
context.Matches.Add(new Match{Id = 11, Date = DateTime.Parse("June 13,2012 18:00"), HomeTeamId = 6, GuestTeamId = 8, Place = "Lvov"});
context.Matches.Add(new Match{Id = 12, Date = DateTime.Parse("June 13,2012 20:45"), HomeTeamId = 5, GuestTeamId = 7, Place = "Kharkov"});
context.Matches.Add(new Match{Id = 13, Date = DateTime.Parse("June 14,2012 18:00"), HomeTeamId = 10, GuestTeamId = 12, Place = "Poznan"});
context.Matches.Add(new Match{Id = 14, Date = DateTime.Parse("June 14,2012 20:45"), HomeTeamId = 9, GuestTeamId = 11, Place = "Gdansk"});
context.Matches.Add(new Match{Id = 15, Date = DateTime.Parse("June 15,2012 18:00"), HomeTeamId = 16, GuestTeamId = 14, Place = "Kiev"});
context.Matches.Add(new Match{Id = 16, Date = DateTime.Parse("June 15,2012 20:45"), HomeTeamId = 15, GuestTeamId = 13, Place = "Donetsk"});
context.Matches.Add(new Match{Id = 17, Date = DateTime.Parse("June 16,2012 20:45"), HomeTeamId = 4, GuestTeamId = 1, Place = "Wroclaw"});
context.Matches.Add(new Match{Id = 18, Date = DateTime.Parse("June 16,2012 20:45"), HomeTeamId = 2, GuestTeamId = 3, Place = "Warsaw"});
context.Matches.Add(new Match{Id = 19, Date = DateTime.Parse("June 17,2012 20:45"), HomeTeamId = 8, GuestTeamId = 5, Place = "Kharkov"});
context.Matches.Add(new Match{Id = 20, Date = DateTime.Parse("June 17,2012 20:45"), HomeTeamId = 6, GuestTeamId = 7, Place = "Lvov"});
context.Matches.Add(new Match{Id = 21, Date = DateTime.Parse("June 18,2012 20:45"), HomeTeamId = 12, GuestTeamId = 9, Place = "Gdansk"});
context.Matches.Add(new Match{Id = 22, Date = DateTime.Parse("June 18,2012 20:45"), HomeTeamId = 10, GuestTeamId = 11, Place = "Poznan"});
context.Matches.Add(new Match{Id = 23, Date = DateTime.Parse("June 19,2012 20:45"), HomeTeamId = 14, GuestTeamId = 15, Place = "Donetsk"});
context.Matches.Add(new Match{Id = 24, Date = DateTime.Parse("June 19,2012 20:45"), HomeTeamId = 16, GuestTeamId = 13, Place = "Kiev"});
        }
    }
}
