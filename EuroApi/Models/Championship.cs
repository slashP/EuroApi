using System.Collections.Generic;

namespace EuroApi.Models
{
    public class Championship
    {
        public int Id { get; set; }
        public List<Group> Groups { get; set; }
        
    }
}