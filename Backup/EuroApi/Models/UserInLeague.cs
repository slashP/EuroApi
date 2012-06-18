using CodeFirstMembershipSharp;

namespace EuroApi.Models
{
    public class UserInLeague
    {
        public int Id { get; set; }
        public int UserLeagueId { get; set; }
        public UserLeague UserLeague { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}