using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroApi.Models
{
    public class PlayerBet
    {
        public int Id { get; set; }
        public int PlayerBetTypeId { get; set; }
        public virtual PlayerBetType PlayerBetType { get; set; }
        public string User { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}