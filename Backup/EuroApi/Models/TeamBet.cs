namespace EuroApi.Models
{
    public class TeamBet
    {
        public int Id { get; set; }
        public int TeamBetTypeId { get; set; }
        public virtual TeamBetType PlayerBetType { get; set; }
        public string User { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}