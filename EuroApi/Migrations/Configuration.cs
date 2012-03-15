using System.Data.Entity.Validation;
using System.Diagnostics;
using EuroApi.Models;

namespace EuroApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EuroApiContext>
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
            try
            {


                AddGroups(context);
                AddTeams(context);
                AddMatches(context);
                AddPlayers(context);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        private void AddGroups(EuroApiContext context)
        {
            //context.Groups.ToList().ForEach(g => context.Groups.Remove(g));
            //context.SaveChanges();
            context.Groups.AddOrUpdate(new Group { Id = 1, Name = "A" });
            context.Groups.AddOrUpdate(new Group { Id = 2, Name = "B" });
            context.Groups.AddOrUpdate(new Group { Id = 3, Name = "C" });
            context.Groups.AddOrUpdate(new Group { Id = 4, Name = "D" });
        }

        private void AddTeams(EuroApiContext context)
        {
            //context.Teams.ToList().ForEach(t => context.Teams.Remove(t));
            //context.SaveChanges();
            context.Teams.AddOrUpdate(new Team { Id = 1, GroupId = 1, Name = "Poland" });
            context.Teams.AddOrUpdate(new Team { Id = 2, GroupId = 1, Name = "Greece" });
            context.Teams.AddOrUpdate(new Team { Id = 3, GroupId = 1, Name = "Russia" });
            context.Teams.AddOrUpdate(new Team { Id = 4, GroupId = 1, Name = "Czech" });
            context.Teams.AddOrUpdate(new Team { Id = 5, GroupId = 2, Name = "Netherlands" });
            context.Teams.AddOrUpdate(new Team { Id = 6, GroupId = 2, Name = "Denmark" });
            context.Teams.AddOrUpdate(new Team { Id = 7, GroupId = 2, Name = "Germany" });
            context.Teams.AddOrUpdate(new Team { Id = 8, GroupId = 2, Name = "Portugal" });
            context.Teams.AddOrUpdate(new Team { Id = 9, GroupId = 3, Name = "Spain" });
            context.Teams.AddOrUpdate(new Team { Id = 10, GroupId = 3, Name = "Italy" });
            context.Teams.AddOrUpdate(new Team { Id = 11, GroupId = 3, Name = "Ireland" });
            context.Teams.AddOrUpdate(new Team { Id = 12, GroupId = 3, Name = "Croatia" });
            context.Teams.AddOrUpdate(new Team { Id = 13, GroupId = 4, Name = "France" });
            context.Teams.AddOrUpdate(new Team { Id = 14, GroupId = 4, Name = "England" });
            context.Teams.AddOrUpdate(new Team { Id = 15, GroupId = 4, Name = "Ukraine" });
            context.Teams.AddOrUpdate(new Team { Id = 16, GroupId = 4, Name = "Sweden" });
        }

        private void AddMatches(EuroApiContext context)
        {
            //context.Matches.ToList().ForEach(m => context.Matches.Remove(m));
            //context.SaveChanges();
            context.Matches.AddOrUpdate(new Match { Id = 1, Date = DateTime.Parse("June 8,2012 18:00"), HomeTeamId = 1, AwayTeamId = 2, Place = "Warsaw" });
            context.Matches.AddOrUpdate(new Match { Id = 2, Date = DateTime.Parse("June 8,2012 20:45"), HomeTeamId = 3, AwayTeamId = 4, Place = "Wroclaw" });
            context.Matches.AddOrUpdate(new Match { Id = 3, Date = DateTime.Parse("June 9,2012 18:00"), HomeTeamId = 5, AwayTeamId = 6, Place = "Kharkov" });
            context.Matches.AddOrUpdate(new Match { Id = 4, Date = DateTime.Parse("June 9,2012 20:45"), HomeTeamId = 7, AwayTeamId = 8, Place = "Lvov" });
            context.Matches.AddOrUpdate(new Match { Id = 5, Date = DateTime.Parse("June 10,2012 18:00"), HomeTeamId = 9, AwayTeamId = 10, Place = "Gdansk" });
            context.Matches.AddOrUpdate(new Match { Id = 6, Date = DateTime.Parse("June 10,2012 20:45"), HomeTeamId = 11, AwayTeamId = 12, Place = "Poznan" });
            context.Matches.AddOrUpdate(new Match { Id = 7, Date = DateTime.Parse("June 11,2012 18:00"), HomeTeamId = 13, AwayTeamId = 14, Place = "Donetsk" });
            context.Matches.AddOrUpdate(new Match { Id = 8, Date = DateTime.Parse("June 11,2012 20:45"), HomeTeamId = 15, AwayTeamId = 16, Place = "Kiev" });
            context.Matches.AddOrUpdate(new Match { Id = 9, Date = DateTime.Parse("June 12,2012 18:00"), HomeTeamId = 2, AwayTeamId = 4, Place = "Wroclaw" });
            context.Matches.AddOrUpdate(new Match { Id = 10, Date = DateTime.Parse("June 12,2012 20:45"), HomeTeamId = 1, AwayTeamId = 3, Place = "Warsaw" });
            context.Matches.AddOrUpdate(new Match { Id = 11, Date = DateTime.Parse("June 13,2012 18:00"), HomeTeamId = 6, AwayTeamId = 8, Place = "Lvov" });
            context.Matches.AddOrUpdate(new Match { Id = 12, Date = DateTime.Parse("June 13,2012 20:45"), HomeTeamId = 5, AwayTeamId = 7, Place = "Kharkov" });
            context.Matches.AddOrUpdate(new Match { Id = 13, Date = DateTime.Parse("June 14,2012 18:00"), HomeTeamId = 10, AwayTeamId = 12, Place = "Poznan" });
            context.Matches.AddOrUpdate(new Match { Id = 14, Date = DateTime.Parse("June 14,2012 20:45"), HomeTeamId = 9, AwayTeamId = 11, Place = "Gdansk" });
            context.Matches.AddOrUpdate(new Match { Id = 15, Date = DateTime.Parse("June 15,2012 18:00"), HomeTeamId = 16, AwayTeamId = 14, Place = "Kiev" });
            context.Matches.AddOrUpdate(new Match { Id = 16, Date = DateTime.Parse("June 15,2012 20:45"), HomeTeamId = 15, AwayTeamId = 13, Place = "Donetsk" });
            context.Matches.AddOrUpdate(new Match { Id = 17, Date = DateTime.Parse("June 16,2012 20:45"), HomeTeamId = 4, AwayTeamId = 1, Place = "Wroclaw" });
            context.Matches.AddOrUpdate(new Match { Id = 18, Date = DateTime.Parse("June 16,2012 20:45"), HomeTeamId = 2, AwayTeamId = 3, Place = "Warsaw" });
            context.Matches.AddOrUpdate(new Match { Id = 19, Date = DateTime.Parse("June 17,2012 20:45"), HomeTeamId = 8, AwayTeamId = 5, Place = "Kharkov" });
            context.Matches.AddOrUpdate(new Match { Id = 20, Date = DateTime.Parse("June 17,2012 20:45"), HomeTeamId = 6, AwayTeamId = 7, Place = "Lvov" });
            context.Matches.AddOrUpdate(new Match { Id = 21, Date = DateTime.Parse("June 18,2012 20:45"), HomeTeamId = 12, AwayTeamId = 9, Place = "Gdansk" });
            context.Matches.AddOrUpdate(new Match { Id = 22, Date = DateTime.Parse("June 18,2012 20:45"), HomeTeamId = 10, AwayTeamId = 11, Place = "Poznan" });
            context.Matches.AddOrUpdate(new Match { Id = 23, Date = DateTime.Parse("June 19,2012 20:45"), HomeTeamId = 14, AwayTeamId = 15, Place = "Donetsk" });
            context.Matches.AddOrUpdate(new Match { Id = 24, Date = DateTime.Parse("June 19,2012 20:45"), HomeTeamId = 16, AwayTeamId = 13, Place = "Kiev" });

            // Knockout phase
            context.KnockoutMatches.AddOrUpdate(new KnockoutMatch { Type = 1, Id = 1, Date = DateTime.Parse("June 21, 2012 20:45"), HomeTeamId = 16, AwayTeamId = 15, Place = "Warzaw" });
            context.KnockoutMatches.AddOrUpdate(new KnockoutMatch { Type = 1, Id = 2, Date = DateTime.Parse("June 22, 2012 20:45"), HomeTeamId = 16, AwayTeamId = 15, Place = "Gdansk" });
            context.KnockoutMatches.AddOrUpdate(new KnockoutMatch { Type = 1, Id = 3, Date = DateTime.Parse("June 23, 2012 20:45"), HomeTeamId = 16, AwayTeamId = 15, Place = "Donetsk" });
            context.KnockoutMatches.AddOrUpdate(new KnockoutMatch { Type = 1, Id = 4, Date = DateTime.Parse("June 24, 2012 20:45"), HomeTeamId = 16, AwayTeamId = 15, Place = "Kiev" });
            context.KnockoutMatches.AddOrUpdate(new KnockoutMatch { Type = 2, Id = 5, Date = DateTime.Parse("June 27, 2012 20:45"), HomeTeamId = 16, AwayTeamId = 15, Place = "Donetsk" });
            context.KnockoutMatches.AddOrUpdate(new KnockoutMatch { Type = 2, Id = 6, Date = DateTime.Parse("June 28, 2012 20:45"), HomeTeamId = 16, AwayTeamId = 15, Place = "Warzaw" });
            context.KnockoutMatches.AddOrUpdate(new KnockoutMatch { Type = 3, Id = 7, Date = DateTime.Parse("July 1, 2012 20:45"), HomeTeamId = 16, AwayTeamId = 15, Place = "Kiev" });
        }

        private void AddPlayers(EuroApiContext context)
        {
            context.Players.ToList().ForEach(a => context.Players.Remove(a));
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Maarten Stekelenburg", DateOfBirth = DateTime.Parse("September 22, 1982"), Caps = 45, Goals = 0, Team = "Roma", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 23, Position = "GK", Name = "Michel Vorm", DateOfBirth = DateTime.Parse("October 20, 1983"), Caps = 9, Goals = 0, Team = "Swansea City", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 16, Position = "GK", Name = "Tim Krul", DateOfBirth = DateTime.Parse("April 3, 1988"), Caps = 2, Goals = 0, Team = "Newcastle United", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "John Heitinga (Vice-Captain)", DateOfBirth = DateTime.Parse("November 15, 1983"), Caps = 75, Goals = 7, Team = "Everton", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 4, Position = "DF", Name = "Joris Mathijsen", DateOfBirth = DateTime.Parse("April 5, 1980"), Caps = 79, Goals = 3, Team = "Málaga", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Khalid Boulahrouz", DateOfBirth = DateTime.Parse("December 28, 1981"), Caps = 35, Goals = 0, Team = "VfB Stuttgart", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 5, Position = "DF", Name = "Erik Pieters", DateOfBirth = DateTime.Parse("July 8, 1988"), Caps = 15, Goals = 0, Team = "PSV", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 20, Position = "DF", Name = "Jeffrey Bruma", DateOfBirth = DateTime.Parse("November 13, 1991"), Caps = 4, Goals = 0, Team = "Hamburger SV", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 13, Position = "DF", Name = "Ron Vlaar", DateOfBirth = DateTime.Parse("February 16, 1985"), Caps = 5, Goals = 0, Team = "Feyenoord", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 6, Position = "MF", Name = "Mark van Bommel (Captain)", DateOfBirth = DateTime.Parse("April 22, 1977"), Caps = 74, Goals = 10, Team = "Milan", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "Nigel de Jong", DateOfBirth = DateTime.Parse("November 30, 1984"), Caps = 57, Goals = 1, Team = "Manchester City", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 10, Position = "MF", Name = "Wesley Sneijder", DateOfBirth = DateTime.Parse("June 9, 1984"), Caps = 81, Goals = 23, Team = "Internazionale", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 11, Position = "MF", Name = "Arjen Robben", DateOfBirth = DateTime.Parse("January 23, 1984"), Caps = 54, Goals = 17, Team = "Bayern Munich", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 15, Position = "MF", Name = "Stijn Schaars", DateOfBirth = DateTime.Parse("January 11, 1984"), Caps = 16, Goals = 0, Team = "Sporting", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 14, Position = "MF", Name = "Kevin Strootman", DateOfBirth = DateTime.Parse("February 13, 1990"), Caps = 10, Goals = 1, Team = "PSV", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Georginio Wijnaldum", DateOfBirth = DateTime.Parse("November 11, 1990"), Caps = 2, Goals = 1, Team = "PSV", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 12, Position = "MF", Name = "Urby Emanuelson", DateOfBirth = DateTime.Parse("June 16, 1986"), Caps = 14, Goals = 0, Team = "Milan", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 7, Position = "FW", Name = "Dirk Kuyt", DateOfBirth = DateTime.Parse("July 22, 1980"), Caps = 85, Goals = 24, Team = "Liverpool", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 9, Position = "FW", Name = "Robin van Persie", DateOfBirth = DateTime.Parse("August 6, 1983"), Caps = 62, Goals = 25, Team = "Arsenal", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 17, Position = "FW", Name = "Klaas-Jan Huntelaar", DateOfBirth = DateTime.Parse("August 12, 1983"), Caps = 49, Goals = 31, Team = "Schalke 04", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 19, Position = "FW", Name = "Luuk de Jong", DateOfBirth = DateTime.Parse("August 27, 1990"), Caps = 7, Goals = 1, Team = "Twente", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 22, Position = "FW", Name = "Luciano Narsingh", DateOfBirth = DateTime.Parse("September 13, 1990"), Caps = 0, Goals = 0, Team = "Heerenveen", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 21, Position = "FW", Name = "Ola John", DateOfBirth = DateTime.Parse("May 19, 1992"), Caps = 0, Goals = 0, Team = "Twente", NationalTeam = "Netherlands" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Andreas Isaksson", DateOfBirth = DateTime.Parse("October 3, 1981"), Caps = 91, Goals = 0, Team = "PSV", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 12, Position = "GK", Name = "Johan Wiland", DateOfBirth = DateTime.Parse("January 24, 1981"), Caps = 7, Goals = 0, Team = "Copenhagen", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Mikael Lustig", DateOfBirth = DateTime.Parse("December 13, 1986"), Caps = 23, Goals = 1, Team = "Celtic", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Olof Mellberg", DateOfBirth = DateTime.Parse("September 3, 1977"), Caps = 112, Goals = 7, Team = "Olympiacos", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 4, Position = "DF", Name = "Daniel Majstorovic", DateOfBirth = DateTime.Parse("April 5, 1977"), Caps = 48, Goals = 2, Team = "Celtic", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 5, Position = "DF", Name = "Martin Olsson", DateOfBirth = DateTime.Parse("May 17, 1988"), Caps = 8, Goals = 4, Team = "Blackburn Rovers", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 13, Position = "DF", Name = "Andreas Granqvist", DateOfBirth = DateTime.Parse("April 16, 1985"), Caps = 16, Goals = 2, Team = "Genoa", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 15, Position = "DF", Name = "Mikael Antonsson", DateOfBirth = DateTime.Parse("May 31, 1981"), Caps = 4, Goals = 0, Team = "Bologna", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 17, Position = "DF", Name = "Oscar Wendt", DateOfBirth = DateTime.Parse("October 24, 1985"), Caps = 18, Goals = 0, Team = "Borussia Mönchengladbach", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 19, Position = "DF", Name = "Jonas Olsson", DateOfBirth = DateTime.Parse("March 10, 1983"), Caps = 6, Goals = 0, Team = "West Bromwich Albion", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 6, Position = "MF", Name = "Emir Bajrami", DateOfBirth = DateTime.Parse("March 7, 1988"), Caps = 15, Goals = 2, Team = "Twente", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 7, Position = "MF", Name = "Sebastian Larsson", DateOfBirth = DateTime.Parse("June 6, 1985"), Caps = 39, Goals = 5, Team = "Sunderland", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "Anders Svensson (vice captain)", DateOfBirth = DateTime.Parse("July 17, 1976"), Caps = 126, Goals = 18, Team = "Elfsborg", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 9, Position = "MF", Name = "Kim Källström", DateOfBirth = DateTime.Parse("August 24, 1982"), Caps = 90, Goals = 16, Team = "Lyon", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 16, Position = "MF", Name = "Pontus Wernbloom", DateOfBirth = DateTime.Parse("June 25, 1986"), Caps = 21, Goals = 2, Team = "CSKA Moscow", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Samuel Holmén", DateOfBirth = DateTime.Parse("June 28, 1984"), Caps = 25, Goals = 2, Team = "Istanbul BB", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 20, Position = "MF", Name = "Ola Toivonen", DateOfBirth = DateTime.Parse("July 3, 1986"), Caps = 22, Goals = 4, Team = "PSV", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 22, Position = "MF", Name = "Rasmus Elm", DateOfBirth = DateTime.Parse("March 17, 1988"), Caps = 22, Goals = 1, Team = "AZ", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 10, Position = "FW", Name = "Zlatan Ibrahimovic (captain)", DateOfBirth = DateTime.Parse("October 3, 1981"), Caps = 75, Goals = 29, Team = "Milan", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 11, Position = "FW", Name = "Johan Elmander", DateOfBirth = DateTime.Parse("May 27, 1981"), Caps = 63, Goals = 16, Team = "Galatasaray", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 14, Position = "FW", Name = "Tobias Hysén", DateOfBirth = DateTime.Parse("March 9, 1982"), Caps = 21, Goals = 7, Team = "IFK Göteborg", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 21, Position = "FW", Name = "John Guidetti", DateOfBirth = DateTime.Parse("April 15, 1992"), Caps = 1, Goals = 0, Team = "Feyenoord", NationalTeam = "Sweden" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Hugo Lloris (captain)", DateOfBirth = DateTime.Parse("26 December 1986"), Caps = 31, Goals = 0, Team = "Lyon", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 16, Position = "GK", Name = "Steve Mandanda", DateOfBirth = DateTime.Parse("28 March 1985"), Caps = 14, Goals = 0, Team = "Marseille", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 23, Position = "GK", Name = "Cédric Carrasso", DateOfBirth = DateTime.Parse("30 December 1981"), Caps = 1, Goals = 0, Team = "Bordeaux", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Mathieu Debuchy", DateOfBirth = DateTime.Parse("28 July 1985"), Caps = 3, Goals = 0, Team = "Lille", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Patrice Evra", DateOfBirth = DateTime.Parse("15 May 1981"), Caps = 39, Goals = 0, Team = "Manchester United", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 4, Position = "DF", Name = "Adil Rami", DateOfBirth = DateTime.Parse("27 December 1985"), Caps = 17, Goals = 0, Team = "Valencia", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 5, Position = "DF", Name = "Philippe Mexès", DateOfBirth = DateTime.Parse("30 March 1982"), Caps = 23, Goals = 1, Team = "Milan", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 12, Position = "DF", Name = "Mamadou Sakho", DateOfBirth = DateTime.Parse("13 February 1990"), Caps = 5, Goals = 0, Team = "Paris Saint-Germain", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 13, Position = "DF", Name = "Anthony Réveillère", DateOfBirth = DateTime.Parse("10 November 1979"), Caps = 16, Goals = 1, Team = "Lyon", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 22, Position = "DF", Name = "Éric Abidal", DateOfBirth = DateTime.Parse("11 September 1979"), Caps = 61, Goals = 0, Team = "Barcelona", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 6, Position = "MF", Name = "Yohan Cabaye", DateOfBirth = DateTime.Parse("14 January 1986"), Caps = 10, Goals = 0, Team = "Newcastle United", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 7, Position = "MF", Name = "Franck Ribéry", DateOfBirth = DateTime.Parse("7 April 1983"), Caps = 57, Goals = 7, Team = "Bayern Munich", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "Mathieu Valbuena", DateOfBirth = DateTime.Parse("28 September 1984"), Caps = 10, Goals = 2, Team = "Marseille", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 11, Position = "MF", Name = "Samir Nasri", DateOfBirth = DateTime.Parse("27 June 1987"), Caps = 28, Goals = 3, Team = "Manchester City", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 15, Position = "MF", Name = "Florent Malouda", DateOfBirth = DateTime.Parse("13 June 1980"), Caps = 74, Goals = 8, Team = "Chelsea", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 17, Position = "MF", Name = "Yann M'Vila", DateOfBirth = DateTime.Parse("29 June 1990"), Caps = 18, Goals = 1, Team = "Rennes", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Alou Diarra", DateOfBirth = DateTime.Parse("15 July 1981"), Caps = 38, Goals = 0, Team = "Marseille", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 19, Position = "MF", Name = "Marvin Martin", DateOfBirth = DateTime.Parse("10 January 1988"), Caps = 9, Goals = 2, Team = "Sochaux", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 21, Position = "MF", Name = "Morgan Amalfitano", DateOfBirth = DateTime.Parse("20 March 1985"), Caps = 1, Goals = 0, Team = "Marseille", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 9, Position = "FW", Name = "Olivier Giroud", DateOfBirth = DateTime.Parse("30 September 1986"), Caps = 3, Goals = 1, Team = "Montpellier", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 10, Position = "FW", Name = "Louis Saha", DateOfBirth = DateTime.Parse("8 August 1978"), Caps = 20, Goals = 4, Team = "Tottenham Hotspur", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 14, Position = "FW", Name = "Jérémy Menez", DateOfBirth = DateTime.Parse("7 May 1987"), Caps = 10, Goals = 0, Team = "Paris Saint-Germain", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 20, Position = "FW", Name = "Kévin Gameiro", DateOfBirth = DateTime.Parse("9 May 1987"), Caps = 8, Goals = 1, Team = "Paris Saint-Germain", NationalTeam = "France" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Joe Hart", DateOfBirth = DateTime.Parse("19 April 1987"), Caps = 17, Goals = 0, Team = "Manchester City", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 13, Position = "GK", Name = "Robert Green", DateOfBirth = DateTime.Parse("18 January 1980"), Caps = 11, Goals = 0, Team = "West Ham United", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 21, Position = "GK", Name = "Scott Carson", DateOfBirth = DateTime.Parse("3 September 1985"), Caps = 4, Goals = 0, Team = "Bursaspor", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 12, Position = "DF", Name = "Ashley Cole", DateOfBirth = DateTime.Parse("20 December 1980"), Caps = 93, Goals = 0, Team = "Chelsea", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Glen Johnson", DateOfBirth = DateTime.Parse("23 August 1984"), Caps = 35, Goals = 1, Team = "Liverpool", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 15, Position = "DF", Name = "Joleon Lescott", DateOfBirth = DateTime.Parse("16 August 1982"), Caps = 14, Goals = 0, Team = "Manchester City", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Micah Richards", DateOfBirth = DateTime.Parse("24 June 1988"), Caps = 13, Goals = 1, Team = "Manchester City", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 6, Position = "DF", Name = "Gary Cahill", DateOfBirth = DateTime.Parse("19 December 1985"), Caps = 8, Goals = 2, Team = "Chelsea", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Leighton Baines", DateOfBirth = DateTime.Parse("11 December 1984"), Caps = 7, Goals = 0, Team = "Everton", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 14, Position = "DF", Name = "Phil Jones", DateOfBirth = DateTime.Parse("21 February 1992"), Caps = 4, Goals = 0, Team = "Manchester United", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 5, Position = "DF", Name = "Chris Smalling", DateOfBirth = DateTime.Parse("22 November 1989"), Caps = 3, Goals = 0, Team = "Manchester United", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Kyle Walker", DateOfBirth = DateTime.Parse("29 May 1990"), Caps = 2, Goals = 0, Team = "Tottenham Hotspur", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 10, Position = "MF", Name = "Steven Gerrard", DateOfBirth = DateTime.Parse("30 May 1980"), Caps = 90, Goals = 19, Team = "Liverpool", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 4, Position = "MF", Name = "Gareth Barry", DateOfBirth = DateTime.Parse("23 February 1981"), Caps = 52, Goals = 3, Team = "Manchester City", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Stewart Downing", DateOfBirth = DateTime.Parse("22 July 1984"), Caps = 33, Goals = 0, Team = "Liverpool", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 16, Position = "MF", Name = "James Milner", DateOfBirth = DateTime.Parse("4 January 1986"), Caps = 24, Goals = 0, Team = "Manchester City", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 17, Position = "MF", Name = "Theo Walcott", DateOfBirth = DateTime.Parse("16 March 1989"), Caps = 22, Goals = 3, Team = "Arsenal", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 7, Position = "MF", Name = "Ashley Young", DateOfBirth = DateTime.Parse("9 July 1985"), Caps = 19, Goals = 5, Team = "Manchester United", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "Scott Parker (c)", DateOfBirth = DateTime.Parse("13 October 1980"), Caps = 11, Goals = 0, Team = "Tottenham Hotspur", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 11, Position = "MF", Name = "Adam Johnson", DateOfBirth = DateTime.Parse("14 July 1987"), Caps = 10, Goals = 2, Team = "Manchester City", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Tom Cleverley", DateOfBirth = DateTime.Parse("12 August 1989"), Caps = 0, Goals = 0, Team = "Manchester United", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 0, Position = "FW", Name = "Wayne Rooney", DateOfBirth = DateTime.Parse("24 October 1985"), Caps = 73, Goals = 28, Team = "Manchester United", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 0, Position = "FW", Name = "Darren Bent", DateOfBirth = DateTime.Parse("6 February 1984"), Caps = 13, Goals = 4, Team = "Aston Villa", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 9, Position = "FW", Name = "Danny Welbeck", DateOfBirth = DateTime.Parse("26 November 1990"), Caps = 4, Goals = 0, Team = "Manchester United", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 20, Position = "FW", Name = "Daniel Sturridge", DateOfBirth = DateTime.Parse("1 September 1989"), Caps = 2, Goals = 0, Team = "Chelsea", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 19, Position = "FW", Name = "Fraizer Campbell", DateOfBirth = DateTime.Parse("13 September 1987"), Caps = 1, Goals = 0, Team = "Sunderland", NationalTeam = "England" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Iker Casillas (captain)", DateOfBirth = DateTime.Parse("20 May 1981"), Caps = 128, Goals = 0, Team = "Real Madrid", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 12, Position = "GK", Name = "Víctor Valdés", DateOfBirth = DateTime.Parse("14 January 1982"), Caps = 7, Goals = 0, Team = "Barcelona", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 23, Position = "GK", Name = "Pepe Reina", DateOfBirth = DateTime.Parse("31 August 1982"), Caps = 24, Goals = 0, Team = "Liverpool", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Andoni Iraola", DateOfBirth = DateTime.Parse("22 June 1982"), Caps = 7, Goals = 0, Team = "Athletic Bilbao", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Gerard Piqué", DateOfBirth = DateTime.Parse("2 February 1987"), Caps = 38, Goals = 4, Team = "Barcelona", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 5, Position = "DF", Name = "Carles Puyol", DateOfBirth = DateTime.Parse("13 April 1978"), Caps = 99, Goals = 3, Team = "Barcelona", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 15, Position = "DF", Name = "Sergio Ramos", DateOfBirth = DateTime.Parse("30 March 1986"), Caps = 83, Goals = 6, Team = "Real Madrid", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 17, Position = "DF", Name = "Álvaro Arbeloa", DateOfBirth = DateTime.Parse("17 January 1983"), Caps = 33, Goals = 0, Team = "Real Madrid", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 24, Position = "DF", Name = "Jordi Alba", DateOfBirth = DateTime.Parse("21 March 1989"), Caps = 3, Goals = 0, Team = "Valencia", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 4, Position = "MF", Name = "Thiago Alcântara", DateOfBirth = DateTime.Parse("11 April 1991"), Caps = 3, Goals = 0, Team = "Barcelona", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 6, Position = "MF", Name = "Andrés Iniesta", DateOfBirth = DateTime.Parse("11 May 1984"), Caps = 64, Goals = 11, Team = "Barcelona", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 7, Position = "MF", Name = "Iker Muniain", DateOfBirth = DateTime.Parse("19 December 1992"), Caps = 1, Goals = 0, Team = "Athletic Bilbao", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "Xavi Hernández", DateOfBirth = DateTime.Parse("25 January 1980"), Caps = 108, Goals = 10, Team = "Barcelona", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 10, Position = "MF", Name = "Cesc Fàbregas", DateOfBirth = DateTime.Parse("4 May 1987"), Caps = 63, Goals = 8, Team = "Barcelona", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 13, Position = "MF", Name = "Juan Mata", DateOfBirth = DateTime.Parse("28 April 1988"), Caps = 16, Goals = 5, Team = "Chelsea", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 14, Position = "MF", Name = "Xabi Alonso", DateOfBirth = DateTime.Parse("25 November 1981"), Caps = 93, Goals = 12, Team = "Real Madrid", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 16, Position = "MF", Name = "Sergio Busquets", DateOfBirth = DateTime.Parse("16 July 1988"), Caps = 38, Goals = 0, Team = "Barcelona", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Javi Martínez", DateOfBirth = DateTime.Parse("2 September 1988"), Caps = 7, Goals = 0, Team = "Athletic Bilbao", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 20, Position = "MF", Name = "Santi Cazorla", DateOfBirth = DateTime.Parse("13 December 1984"), Caps = 40, Goals = 4, Team = "Málaga", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 21, Position = "MF", Name = "David Silva", DateOfBirth = DateTime.Parse("8 January 1986"), Caps = 55, Goals = 15, Team = "Manchester City", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 22, Position = "MF", Name = "Jesús Navas", DateOfBirth = DateTime.Parse("21 November 1985"), Caps = 15, Goals = 1, Team = "Sevilla", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 9, Position = "FW", Name = "Roberto Soldado", DateOfBirth = DateTime.Parse("27 May 1985"), Caps = 3, Goals = 3, Team = "Valencia", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 19, Position = "FW", Name = "Fernando Llorente", DateOfBirth = DateTime.Parse("26 February 1985"), Caps = 20, Goals = 7, Team = "Athletic Bilbao", NationalTeam = "Spain" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Manuel Neuer", DateOfBirth = DateTime.Parse("27 March 1986"), Caps = 25, Goals = 0, Team = "Bayern Munich", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 12, Position = "GK", Name = "Tim Wiese", DateOfBirth = DateTime.Parse("17 December 1981"), Caps = 6, Goals = 0, Team = "Werder Bremen", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Marcel Schmelzer", DateOfBirth = DateTime.Parse("22 January 1988"), Caps = 5, Goals = 0, Team = "Borussia Dortmund", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Benedikt Höwedes", DateOfBirth = DateTime.Parse("29 February 1988"), Caps = 7, Goals = 0, Team = "Schalke 04", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 4, Position = "DF", Name = "Dennis Aogo", DateOfBirth = DateTime.Parse("14 January 1987"), Caps = 10, Goals = 0, Team = "Hamburger SV", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 5, Position = "DF", Name = "Mats Hummels", DateOfBirth = DateTime.Parse("16 December 1988"), Caps = 13, Goals = 0, Team = "Borussia Dortmund", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 14, Position = "DF", Name = "Holger Badstuber", DateOfBirth = DateTime.Parse("13 March 1989"), Caps = 19, Goals = 1, Team = "Bayern Munich", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 15, Position = "DF", Name = "Christian Träsch", DateOfBirth = DateTime.Parse("1 September 1987"), Caps = 10, Goals = 0, Team = "VfL Wolfsburg", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 20, Position = "DF", Name = "Jérôme Boateng", DateOfBirth = DateTime.Parse("3 September 1988"), Caps = 20, Goals = 0, Team = "Bayern Munich", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 6, Position = "MF", Name = "Sami Khedira", DateOfBirth = DateTime.Parse("4 April 1987"), Caps = 25, Goals = 1, Team = "Real Madrid", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 7, Position = "MF", Name = "Simon Rolfes", DateOfBirth = DateTime.Parse("21 January 1982"), Caps = 26, Goals = 2, Team = "Bayer Leverkusen", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "Mesut Özil", DateOfBirth = DateTime.Parse("15 October 1988"), Caps = 31, Goals = 8, Team = "Real Madrid", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 9, Position = "MF", Name = "André Schürrle", DateOfBirth = DateTime.Parse("6 November 1990"), Caps = 12, Goals = 5, Team = "Bayer Leverkusen", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 13, Position = "MF", Name = "Thomas Müller", DateOfBirth = DateTime.Parse("13 September 1989"), Caps = 26, Goals = 10, Team = "Bayern Munich", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Toni Kroos", DateOfBirth = DateTime.Parse("4 January 1990"), Caps = 25, Goals = 2, Team = "Bayern Munich", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 21, Position = "MF", Name = "Marco Reus", DateOfBirth = DateTime.Parse("31 May 1989"), Caps = 4, Goals = 0, Team = "Borussia Mönchengladbach", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 24, Position = "MF", Name = "Lars Bender", DateOfBirth = DateTime.Parse("27 April 1989"), Caps = 4, Goals = 0, Team = "Bayer Leverkusen", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 11, Position = "FW", Name = "Miroslav Klose", DateOfBirth = DateTime.Parse("9 June 1978"), Caps = 114, Goals = 63, Team = "Lazio", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 19, Position = "FW", Name = "Cacau", DateOfBirth = DateTime.Parse("27 March 1981"), Caps = 22, Goals = 6, Team = "VfB Stuttgart", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 23, Position = "FW", Name = "Mario Gómez", DateOfBirth = DateTime.Parse("10 July 1985"), Caps = 51, Goals = 21, Team = "Bayern Munich", NationalTeam = "Germany" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Alexandros Tzorvas", DateOfBirth = DateTime.Parse("12 August 1982"), Caps = 16, Goals = 0, Team = "Palermo", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 12, Position = "GK", Name = "Orestis Karnezis", DateOfBirth = DateTime.Parse("11 July 1985"), Caps = 1, Goals = 0, Team = "Panathinaikos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Giannis Maniatis", DateOfBirth = DateTime.Parse("12 October 1986"), Caps = 7, Goals = 0, Team = "Olympiacos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Iosif Cholevas", DateOfBirth = DateTime.Parse("27 June 1984"), Caps = 2, Goals = 0, Team = "Olympiacos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 4, Position = "DF", Name = "Nikos Spyropoulos", DateOfBirth = DateTime.Parse("10 October 1983"), Caps = 27, Goals = 1, Team = "Panathinaikos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 8, Position = "DF", Name = "Avraam Papadopoulos", DateOfBirth = DateTime.Parse("3 December 1984"), Caps = 31, Goals = 0, Team = "Olympiacos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 15, Position = "DF", Name = "Vasilis Torosidis", DateOfBirth = DateTime.Parse("10 June 1985"), Caps = 43, Goals = 5, Team = "Olympiacos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 19, Position = "DF", Name = "Sokratis Papastathopoulos", DateOfBirth = DateTime.Parse("9 June 1988"), Caps = 26, Goals = 0, Team = "Werder Bremen", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 22, Position = "DF", Name = "Kyriakos Papadopoulos", DateOfBirth = DateTime.Parse("23 February 1992"), Caps = 7, Goals = 2, Team = "Schalke 04", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 6, Position = "MF", Name = "Grigoris Makos", DateOfBirth = DateTime.Parse("18 January 1987"), Caps = 10, Goals = 0, Team = "AEK Athens", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 10, Position = "MF", Name = "Giorgos Karagounis", DateOfBirth = DateTime.Parse("6 March 1977"), Caps = 115, Goals = 8, Team = "Panathinaikos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 16, Position = "MF", Name = "Kostas Fortounis", DateOfBirth = DateTime.Parse("16 October 1992"), Caps = 1, Goals = 0, Team = "Kaiserslautern", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Giorgos Fotakis", DateOfBirth = DateTime.Parse("29 October 1981"), Caps = 9, Goals = 2, Team = "PAOK", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 21, Position = "MF", Name = "Kostas Katsouranis", DateOfBirth = DateTime.Parse("21 June 1979"), Caps = 89, Goals = 9, Team = "Panathinaikos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 23, Position = "MF", Name = "Giannis Fetfatzidis", DateOfBirth = DateTime.Parse("21 December 1990"), Caps = 12, Goals = 3, Team = "Olympiacos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 7, Position = "FW", Name = "Giorgos Samaras", DateOfBirth = DateTime.Parse("21 February 1985"), Caps = 52, Goals = 7, Team = "Celtic", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 9, Position = "FW", Name = "Nikos Lyberopoulos", DateOfBirth = DateTime.Parse("4 August 1975"), Caps = 74, Goals = 13, Team = "AEK Athens", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 11, Position = "FW", Name = "Stefanos Athanasiadis", DateOfBirth = DateTime.Parse("24 December 1988"), Caps = 3, Goals = 0, Team = "PAOK", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 14, Position = "FW", Name = "Dimitris Salpigidis", DateOfBirth = DateTime.Parse("18 August 1981"), Caps = 55, Goals = 7, Team = "PAOK", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 17, Position = "FW", Name = "Theofanis Gekas", DateOfBirth = DateTime.Parse("23 May 1980"), Caps = 56, Goals = 21, Team = "Samsunspor", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 20, Position = "FW", Name = "Lazaros Christodoulopoulos", DateOfBirth = DateTime.Parse("19 December 1986"), Caps = 7, Goals = 0, Team = "Panathinaikos", NationalTeam = "Greece" });
            context.Players.Add(new Player { Number = 0, Position = "GK", Name = "Petr Cech", DateOfBirth = DateTime.Parse("May 20, 1982"), Caps = 88, Goals = 0, Team = "Chelsea", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "GK", Name = "Jaroslav Drobný", DateOfBirth = DateTime.Parse("October 18, 1979"), Caps = 5, Goals = 0, Team = "Hamburger SV", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Michal Kadlec", DateOfBirth = DateTime.Parse("December 13, 1984"), Caps = 32, Goals = 7, Team = "Bayer Leverkusen", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Tomáš Sivok", DateOfBirth = DateTime.Parse("September 15, 1983"), Caps = 23, Goals = 3, Team = "Besiktas", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Daniel Pudil", DateOfBirth = DateTime.Parse("September 27, 1985"), Caps = 22, Goals = 2, Team = "Cesena", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Roman Hubník", DateOfBirth = DateTime.Parse("June 6, 1984"), Caps = 20, Goals = 2, Team = "Hertha Berlin", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Jan Rajnoch", DateOfBirth = DateTime.Parse("September 30, 1981"), Caps = 15, Goals = 0, Team = "Sivasspor", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Theodor Gebre Selassie", DateOfBirth = DateTime.Parse("December 24, 1986"), Caps = 7, Goals = 0, Team = "Slovan Liberec", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "František Rajtoral", DateOfBirth = DateTime.Parse("March 12, 1986"), Caps = 0, Goals = 0, Team = "Viktoria Plzen", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Tomáš Rosický", DateOfBirth = DateTime.Parse("October 4, 1980"), Caps = 85, Goals = 20, Team = "Arsenal", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Jaroslav Plašil", DateOfBirth = DateTime.Parse("January 5, 1982"), Caps = 69, Goals = 6, Team = "Bordeaux", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Tomáš Hübschman", DateOfBirth = DateTime.Parse("September 4, 1981"), Caps = 40, Goals = 0, Team = "Shakhtar Donetsk", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Jan Rezek", DateOfBirth = DateTime.Parse("May 5, 1982"), Caps = 11, Goals = 3, Team = "Anorthosis Famagusta", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Daniel Kolár", DateOfBirth = DateTime.Parse("October 27, 1985"), Caps = 8, Goals = 1, Team = "Viktoria Plzen", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Milan Petržela", DateOfBirth = DateTime.Parse("June 19, 1983"), Caps = 8, Goals = 0, Team = "Viktoria Plzen", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Václav Pilar", DateOfBirth = DateTime.Parse("October 13, 1988"), Caps = 6, Goals = 1, Team = "Viktoria Plzen", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Petr Jirácek", DateOfBirth = DateTime.Parse("March 2, 1986"), Caps = 5, Goals = 1, Team = "Wolfsburg", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "FW", Name = "Milan Baroš", DateOfBirth = DateTime.Parse("October 28, 1981"), Caps = 86, Goals = 39, Team = "Galatasaray", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "FW", Name = "David Lafata", DateOfBirth = DateTime.Parse("September 18, 1981"), Caps = 15, Goals = 2, Team = "Baumit Jablonec", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 0, Position = "FW", Name = "Tomáš Pekhart", DateOfBirth = DateTime.Parse("May 26, 1989"), Caps = 8, Goals = 0, Team = "Nürnberg", NationalTeam = "Czech" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Vladimir Gabulov", DateOfBirth = DateTime.Parse("19 October 1983"), Caps = 7, Goals = 0, Team = "Anzhi Makhachkala", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 16, Position = "GK", Name = "Sergey Ryzhikov", DateOfBirth = DateTime.Parse("19 September 1980"), Caps = 1, Goals = 0, Team = "Rubin Kazan", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Aleksandr Anyukov", DateOfBirth = DateTime.Parse("28 September 1982"), Caps = 63, Goals = 1, Team = "Zenit Saint Petersburg", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Vasili Berezutskiy", DateOfBirth = DateTime.Parse("20 June 1982"), Caps = 61, Goals = 2, Team = "CSKA Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 4, Position = "DF", Name = "Sergei Ignashevich", DateOfBirth = DateTime.Parse("14 July 1979"), Caps = 72, Goals = 5, Team = "CSKA Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 5, Position = "DF", Name = "Yuri Zhirkov", DateOfBirth = DateTime.Parse("20 August 1983"), Caps = 49, Goals = 0, Team = "Anzhi Makhachkala", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 13, Position = "DF", Name = "Aleksei Berezutskiy", DateOfBirth = DateTime.Parse("20 June 1982"), Caps = 45, Goals = 0, Team = "CSKA Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 19, Position = "DF", Name = "Roman Shishkin", DateOfBirth = DateTime.Parse("27 January 1987"), Caps = 8, Goals = 0, Team = "Lokomotiv Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 6, Position = "MF", Name = "Roman Shirokov", DateOfBirth = DateTime.Parse("6 July 1981"), Caps = 19, Goals = 4, Team = "Zenit Saint Petersburg", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 7, Position = "MF", Name = "Igor Denisov", DateOfBirth = DateTime.Parse("17 May 1984"), Caps = 23, Goals = 0, Team = "Zenit Saint Petersburg", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "Konstantin Zyryanov", DateOfBirth = DateTime.Parse("5 October 1977"), Caps = 47, Goals = 7, Team = "Zenit Saint Petersburg", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 11, Position = "MF", Name = "Alan Dzagoev", DateOfBirth = DateTime.Parse("17 June 1990"), Caps = 18, Goals = 4, Team = "CSKA Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 15, Position = "MF", Name = "Igor Semshov", DateOfBirth = DateTime.Parse("6 April 1978"), Caps = 56, Goals = 3, Team = "Dynamo Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 17, Position = "MF", Name = "Diniyar Bilyaletdinov", DateOfBirth = DateTime.Parse("27 February 1985"), Caps = 46, Goals = 6, Team = "Spartak Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Denis Glushakov", DateOfBirth = DateTime.Parse("27 January 1987"), Caps = 8, Goals = 1, Team = "Lokomotiv Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 22, Position = "MF", Name = "Dmitri Kombarov", DateOfBirth = DateTime.Parse("22 January 1987"), Caps = 1, Goals = 0, Team = "Spartak Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 9, Position = "FW", Name = "Roman Pavlyuchenko", DateOfBirth = DateTime.Parse("15 December 1981"), Caps = 45, Goals = 20, Team = "Lokomotiv Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 10, Position = "FW", Name = "Andrei Arshavin (c)", DateOfBirth = DateTime.Parse("29 May 1981"), Caps = 68, Goals = 17, Team = "Zenit Saint Petersburg", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 14, Position = "FW", Name = "Pavel Pogrebnyak", DateOfBirth = DateTime.Parse("8 November 1983"), Caps = 31, Goals = 8, Team = "Fulham", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 20, Position = "FW", Name = "Aleksandr Kerzhakov", DateOfBirth = DateTime.Parse("27 November 1982"), Caps = 58, Goals = 17, Team = "Zenit Saint Petersburg", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 21, Position = "FW", Name = "Aleksandr Kokorin", DateOfBirth = DateTime.Parse("19 March 1991"), Caps = 2, Goals = 0, Team = "Dynamo Moscow", NationalTeam = "Russia" });
            context.Players.Add(new Player { Number = 0, Position = "GK", Name = "Lukasz Fabianski", DateOfBirth = DateTime.Parse("April 18, 1985"), Caps = 20, Goals = 0, Team = "Arsenal", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "GK", Name = "Wojciech Szczesny", DateOfBirth = DateTime.Parse("April 18, 1990"), Caps = 9, Goals = 0, Team = "Arsenal", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Marcin Wasilewski", DateOfBirth = DateTime.Parse("June 9, 1980"), Caps = 45, Goals = 1, Team = "Anderlecht", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Jakub Wawrzyniak", DateOfBirth = DateTime.Parse("July 7, 1983"), Caps = 25, Goals = 0, Team = "Legia Warsaw", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Tomasz Jodlowiec", DateOfBirth = DateTime.Parse("March 22, 1985"), Caps = 24, Goals = 0, Team = "Polonia Warsaw", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Lukasz Piszczek", DateOfBirth = DateTime.Parse("June 3, 1985"), Caps = 22, Goals = 0, Team = "Borussia Dortmund", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Grzegorz Wojtkowiak", DateOfBirth = DateTime.Parse("January 26, 1984"), Caps = 17, Goals = 0, Team = "Lech Poznan", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Damien Perquis", DateOfBirth = DateTime.Parse("October 4, 1984"), Caps = 5, Goals = 0, Team = "Sochaux", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Sebastian Boenisch", DateOfBirth = DateTime.Parse("February 1, 1987"), Caps = 3, Goals = 0, Team = "Werder Bremen", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Marcin Kaminski", DateOfBirth = DateTime.Parse("January 15, 1992"), Caps = 1, Goals = 0, Team = "Lech Poznan", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "DF", Name = "Dariusz Dudka", DateOfBirth = DateTime.Parse("December 9, 1983"), Caps = 61, Goals = 2, Team = "Auxerre", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Jakub Blaszczykowski (Captain)", DateOfBirth = DateTime.Parse("December 14, 1985"), Caps = 49, Goals = 8, Team = "Borussia Dortmund", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Sebastian Mila", DateOfBirth = DateTime.Parse("July 10, 1982"), Caps = 30, Goals = 6, Team = "Slask Wroclaw", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Slawomir Peszko", DateOfBirth = DateTime.Parse("February 19, 1985"), Caps = 25, Goals = 1, Team = "1. FC Köln", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Ludovic Obraniak", DateOfBirth = DateTime.Parse("November 10, 1984"), Caps = 21, Goals = 4, Team = "Bordeaux", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Adrian Mierzejewski", DateOfBirth = DateTime.Parse("November 4, 1986"), Caps = 20, Goals = 1, Team = "Trabzonspor", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Maciej Rybus", DateOfBirth = DateTime.Parse("August 19, 1989"), Caps = 19, Goals = 1, Team = "Terek Grozny", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Adam Matuszczyk", DateOfBirth = DateTime.Parse("February 14, 1989"), Caps = 17, Goals = 1, Team = "Fortuna Düsseldorf", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "MF", Name = "Eugen Polanski", DateOfBirth = DateTime.Parse("March 17, 1986"), Caps = 5, Goals = 0, Team = "Mainz 05", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "FW", Name = "Robert Lewandowski", DateOfBirth = DateTime.Parse("August 21, 1988"), Caps = 40, Goals = 13, Team = "Borussia Dortmund", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "FW", Name = "Ireneusz Jelen", DateOfBirth = DateTime.Parse("April 9, 1981"), Caps = 29, Goals = 5, Team = "Lille", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 0, Position = "FW", Name = "Kamil Grosicki", DateOfBirth = DateTime.Parse("June 8, 1988"), Caps = 11, Goals = 0, Team = "Sivasspor", NationalTeam = "Poland" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Oleksandr Shovkovskiy", DateOfBirth = DateTime.Parse("2 January 1975"), Caps = 92, Goals = 0, Team = "Dynamo Kyiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 21, Position = "GK", Name = "Andriy Dikan", DateOfBirth = DateTime.Parse("16 July 1977"), Caps = 8, Goals = 0, Team = "Spartak Moscow", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Oleksandr Kucher", DateOfBirth = DateTime.Parse("22 October 1982"), Caps = 28, Goals = 1, Team = "Shakhtar Donetsk", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 15, Position = "DF", Name = "Taras Mykhalyk", DateOfBirth = DateTime.Parse("28 October 1983"), Caps = 25, Goals = 0, Team = "Dynamo Kyiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 7, Position = "DF", Name = "Vitaliy Mandzyuk8 9", DateOfBirth = DateTime.Parse("24 January 1986"), Caps = 19, Goals = 0, Team = "Dnipro Dnipropetrovsk", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 23, Position = "DF", Name = "Yevhen Khacheridi", DateOfBirth = DateTime.Parse("28 July 1987"), Caps = 8, Goals = 0, Team = "Dynamo Kyiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Bohdan Butko", DateOfBirth = DateTime.Parse("13 January 1991"), Caps = 7, Goals = 0, Team = "Illichivets Mariupol", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 12, Position = "DF", Name = "Yevhen Selin", DateOfBirth = DateTime.Parse("9 May 1988"), Caps = 5, Goals = 1, Team = "Vorskla Poltava", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 4, Position = "MF", Name = "Anatoliy Tymoshchuk", DateOfBirth = DateTime.Parse("30 March 1979"), Caps = 114, Goals = 4, Team = "Bayern Munich", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 9, Position = "MF", Name = "Oleh Husyev", DateOfBirth = DateTime.Parse("25 April 1983"), Caps = 69, Goals = 9, Team = "Dynamo Kyiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 5, Position = "MF", Name = "Ruslan Rotan", DateOfBirth = DateTime.Parse("29 October 1981"), Caps = 56, Goals = 6, Team = "Dnipro Dnipropetrovsk", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Serhiy Nazarenko", DateOfBirth = DateTime.Parse("16 February 1980"), Caps = 47, Goals = 12, Team = "Tavriya Simferopol", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 8, Position = "FW", Name = "Oleksandr Aliyev", DateOfBirth = DateTime.Parse("3 February 1985"), Caps = 25, Goals = 6, Team = "Dynamo Kyiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 19, Position = "FW", Name = "Andriy Yarmolenko", DateOfBirth = DateTime.Parse("23 October 1989"), Caps = 18, Goals = 7, Team = "Dynamo Kyiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 14, Position = "MF", Name = "Yevhen Konoplyanka", DateOfBirth = DateTime.Parse("29 September 1989"), Caps = 16, Goals = 5, Team = "Dnipro Dnipropetrovsk", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 20, Position = "MF", Name = "Denys Harmash", DateOfBirth = DateTime.Parse("19 April 1990"), Caps = 4, Goals = 0, Team = "Dynamo Kyiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 16, Position = "FW", Name = "Andriy Voronin", DateOfBirth = DateTime.Parse("21 July 1979"), Caps = 70, Goals = 7, Team = "Dynamo Moscow", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 10, Position = "FW", Name = "Artem Milevskiy", DateOfBirth = DateTime.Parse("12 January 1985"), Caps = 43, Goals = 7, Team = "Dynamo Kyiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 22, Position = "FW", Name = "Marko Devych", DateOfBirth = DateTime.Parse("27 October 1983"), Caps = 18, Goals = 2, Team = "Metalist Kharkiv", NationalTeam = "Ukraine" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Eduardo", DateOfBirth = DateTime.Parse("September 19, 1982"), Caps = 27, Goals = 0, Team = "Benfica", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 12, Position = "GK", Name = "Rui Patrício", DateOfBirth = DateTime.Parse("February 15, 1988"), Caps = 10, Goals = 0, Team = "Sporting", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 22, Position = "GK", Name = "Beto", DateOfBirth = DateTime.Parse("May 1, 1982"), Caps = 1, Goals = 0, Team = "CFR Cluj", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Bruno Alves", DateOfBirth = DateTime.Parse("November 27, 1981"), Caps = 48, Goals = 5, Team = "Zenit Saint Petersburg", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Pepe", DateOfBirth = DateTime.Parse("February 26, 1983"), Caps = 38, Goals = 2, Team = "Real Madrid", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 5, Position = "DF", Name = "Fábio Coentrão", DateOfBirth = DateTime.Parse("March 11, 1988"), Caps = 20, Goals = 1, Team = "Real Madrid", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 11, Position = "DF", Name = "João Pereira", DateOfBirth = DateTime.Parse("February 25, 1984"), Caps = 13, Goals = 0, Team = "Sporting", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 14, Position = "DF", Name = "Rolando", DateOfBirth = DateTime.Parse("August 31, 1985"), Caps = 13, Goals = 0, Team = "Porto", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 13, Position = "DF", Name = "Ricardo Costa", DateOfBirth = DateTime.Parse("May 16, 1981"), Caps = 10, Goals = 0, Team = "Valencia", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 6, Position = "DF", Name = "Nélson", DateOfBirth = DateTime.Parse("June 10, 1983"), Caps = 3, Goals = 0, Team = "Betis", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 16, Position = "MF", Name = "Raul Meireles", DateOfBirth = DateTime.Parse("March 17, 1983"), Caps = 54, Goals = 8, Team = "Chelsea", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "João Moutinho", DateOfBirth = DateTime.Parse("September 8, 1986"), Caps = 40, Goals = 2, Team = "Porto", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 4, Position = "MF", Name = "Miguel Veloso", DateOfBirth = DateTime.Parse("May 11, 1986"), Caps = 22, Goals = 2, Team = "Genoa", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 20, Position = "MF", Name = "Paulo Machado", DateOfBirth = DateTime.Parse("March 31, 1986"), Caps = 4, Goals = 0, Team = "Toulouse", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 10, Position = "MF", Name = "Manuel Fernandes", DateOfBirth = DateTime.Parse("February 5, 1986"), Caps = 9, Goals = 2, Team = "Besiktas", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 15, Position = "MF", Name = "Rúben Micael", DateOfBirth = DateTime.Parse("August 19, 1986"), Caps = 7, Goals = 2, Team = "Real Zaragoza", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 7, Position = "FW", Name = "Cristiano Ronaldo (Captain)", DateOfBirth = DateTime.Parse("February 5, 1985"), Caps = 88, Goals = 32, Team = "Real Madrid", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 17, Position = "FW", Name = "Nani", DateOfBirth = DateTime.Parse("November 17, 1986"), Caps = 52, Goals = 12, Team = "Manchester United", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 23, Position = "FW", Name = "Hélder Postiga", DateOfBirth = DateTime.Parse("September 2, 1982"), Caps = 47, Goals = 19, Team = "Real Zaragoza", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 9, Position = "FW", Name = "Hugo Almeida", DateOfBirth = DateTime.Parse("May 23, 1984"), Caps = 40, Goals = 15, Team = "Besiktas", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 19, Position = "FW", Name = "Ricardo Quaresma", DateOfBirth = DateTime.Parse("September 26, 1983"), Caps = 33, Goals = 3, Team = "Besiktas", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 21, Position = "FW", Name = "Nélson Oliveira", DateOfBirth = DateTime.Parse("August 8, 1991"), Caps = 1, Goals = 0, Team = "Benfica", NationalTeam = "Portugal" });
            context.Players.Add(new Player { Number = 1, Position = "GK", Name = "Gianluigi Buffon (c)", DateOfBirth = DateTime.Parse("28 January 1978"), Caps = 113, Goals = 0, Team = "Juventus", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 16, Position = "GK", Name = "Salvatore Sirigu", DateOfBirth = DateTime.Parse("12 January 1987"), Caps = 2, Goals = 0, Team = "Paris Saint-Germain", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 17, Position = "GK", Name = "Emiliano Viviano", DateOfBirth = DateTime.Parse("1 December 1985"), Caps = 6, Goals = 0, Team = "Palermo", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 24, Position = "GK", Name = "Morgan De Sanctis", DateOfBirth = DateTime.Parse("26 March 1977"), Caps = 4, Goals = 0, Team = "Napoli", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 2, Position = "DF", Name = "Christian Maggio", DateOfBirth = DateTime.Parse("11 February 1982"), Caps = 15, Goals = 0, Team = "Napoli", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 3, Position = "DF", Name = "Giorgio Chiellini", DateOfBirth = DateTime.Parse("14 August 1984"), Caps = 50, Goals = 2, Team = "Juventus", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 4, Position = "DF", Name = "Domenico Criscito", DateOfBirth = DateTime.Parse("30 December 1986"), Caps = 19, Goals = 0, Team = "Zenit St. Petersburg", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 6, Position = "DF", Name = "Federico Balzaretti", DateOfBirth = DateTime.Parse("6 December 1981"), Caps = 7, Goals = 0, Team = "Palermo", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 11, Position = "DF", Name = "Ignazio Abate", DateOfBirth = DateTime.Parse("12 November 1986"), Caps = 2, Goals = 0, Team = "Milan", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 14, Position = "DF", Name = "Davide Astori", DateOfBirth = DateTime.Parse("7 January 1987"), Caps = 1, Goals = 0, Team = "Cagliari", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 15, Position = "DF", Name = "Andrea Barzagli", DateOfBirth = DateTime.Parse("8 May 1981"), Caps = 28, Goals = 0, Team = "Juventus", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 19, Position = "DF", Name = "Leonardo Bonucci", DateOfBirth = DateTime.Parse("1 May 1987"), Caps = 13, Goals = 2, Team = "Juventus", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 20, Position = "DF", Name = "Angelo Ogbonna", DateOfBirth = DateTime.Parse("23 May 1988"), Caps = 2, Goals = 0, Team = "Torino", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 5, Position = "MF", Name = "Daniele De Rossi", DateOfBirth = DateTime.Parse("24 July 1983"), Caps = 71, Goals = 10, Team = "Roma", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 8, Position = "MF", Name = "Claudio Marchisio", DateOfBirth = DateTime.Parse("19 January 1986"), Caps = 19, Goals = 1, Team = "Juventus", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 13, Position = "MF", Name = "Thiago Motta", DateOfBirth = DateTime.Parse("28 August 1982"), Caps = 7, Goals = 1, Team = "Paris Saint-Germain", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 18, Position = "MF", Name = "Riccardo Montolivo", DateOfBirth = DateTime.Parse("18 January 1985"), Caps = 32, Goals = 1, Team = "Fiorentina", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 21, Position = "MF", Name = "Andrea Pirlo", DateOfBirth = DateTime.Parse("19 May 1979"), Caps = 82, Goals = 9, Team = "Juventus", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 23, Position = "MF", Name = "Antonio Nocerino", DateOfBirth = DateTime.Parse("9 April 1985"), Caps = 10, Goals = 0, Team = "Milan", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 7, Position = "FW", Name = "Giampaolo Pazzini", DateOfBirth = DateTime.Parse("2 August 1984"), Caps = 24, Goals = 4, Team = "Internazionale", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 9, Position = "FW", Name = "Alessandro Matri", DateOfBirth = DateTime.Parse("19 August 1984"), Caps = 5, Goals = 1, Team = "Juventus", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 10, Position = "FW", Name = "Sebastian Giovinco", DateOfBirth = DateTime.Parse("27 January 1987"), Caps = 7, Goals = 0, Team = "Parma", NationalTeam = "Italy" });
            context.Players.Add(new Player { Number = 22, Position = "FW", Name = "Fabio Borini", DateOfBirth = DateTime.Parse("29 March 1991"), Caps = 1, Goals = 0, Team = "Roma", NationalTeam = "Italy" });


        }
    }
}
