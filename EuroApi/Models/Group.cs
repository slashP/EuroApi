using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuroApi.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}