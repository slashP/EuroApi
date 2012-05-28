namespace EuroApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int InnleggId { get; set; }
        public string Kommentar { get; set; }
        public string Name { get; set; }
        public int GuestbookId { get; set; }
    }
}