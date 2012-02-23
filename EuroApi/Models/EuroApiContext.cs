using System.Data.Entity;

namespace EuroApi.Models
{
    public class EuroApiContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                        .HasRequired(m => m.HomeTeam)
                        .WithMany(t => t.HomeMatches)
                        .HasForeignKey(m => m.HomeTeamId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                        .HasRequired(m => m.GuestTeam)
                        .WithMany(t => t.AwayMatches)
                        .HasForeignKey(m => m.GuestTeamId)
                        .WillCascadeOnDelete(false);
        }

        public DbSet<Group> Groups { get; set; }
    }
}
