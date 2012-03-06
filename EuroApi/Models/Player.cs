using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroApi.Models
{
    public class Player : IComparable<Player>
    {
        public int Id { get; set; }
        public string Team { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int Caps { get; set; }
        public int Goals { get; set; }
        public string NationalTeam { get; set; }

        public string PositionPresentable { get
        {
            switch (Position)
            {
                case "GK":
                    return "Goalkeeper";
                case "DF":
                    return "Defender";
                case "MF":
                    return "Midfielder";
                case "FW":
                    return "Forward";
                default:
                    return "";
            }
        }}

        private readonly List<string> _positions = new List<string>{"GK", "DF", "MF", "FW"};

        public int CompareTo(Player other)
        {
            return _positions.IndexOf(Position) - _positions.IndexOf(other.Position);
        }
    }
}