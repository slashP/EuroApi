using System.Data.Entity;
using CodeFirstMembershipSharp;
using EuroApi.Models;
using User = CodeFirstMembershipSharp.User;

namespace EuroApi.Context
{
    public class FootyFeudContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<KnockoutMatch> KnockoutMatches { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                        .HasRequired(m => m.HomeTeam)
                        .WithMany(t => t.HomeMatches)
                        .HasForeignKey(m => m.HomeTeamId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                        .HasRequired(m => m.AwayTeam)
                        .WithMany(t => t.AwayMatches)
                        .HasForeignKey(m => m.AwayTeamId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<KnockoutMatch>()
                        .HasRequired(m => m.HomeTeam)
                        .WithMany(t => t.KnockoutHomeMatches)
                        .HasForeignKey(m => m.HomeTeamId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<KnockoutMatch>()
                        .HasRequired(m => m.AwayTeam)
                        .WithMany(t => t.KnockoutAwayMatches)
                        .HasForeignKey(m => m.AwayTeamId)
                        .WillCascadeOnDelete(false);
        }

        public DbSet<Group> Groups { get; set; }

        public DbSet<MatchResultBet> MatchResultBets { get; set; }

        public DbSet<KnockoutMatchResultBet> KnockoutMatchResultBets { get; set; }

        public DbSet<Player> Players { get; set; }

        //public DbSet<EuroApi.Models.User> Users { get; set; }

        public DbSet<UserInLeague> UserInLeagues { get; set; }

        public DbSet<UserLeague> UserLeagues { get; set; }

        public DbSet<PlayerBet> PlayerBets { get; set; }

        public DbSet<PlayerBetType> PlayerBetTypes { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Guestbook> Guestbooks { get; set; }
    }
}
