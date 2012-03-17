namespace EuroApi.Models
{
    public class UserLeague
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool PasswordProtected { get; set; }
        public string Password { get; set; }
    }
}