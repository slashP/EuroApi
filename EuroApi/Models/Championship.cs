using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroApi.Models
{
    public class Championship
    {
        public int Id { get; set; }
        public List<Group> Groups { get; set; }
        
    }
}