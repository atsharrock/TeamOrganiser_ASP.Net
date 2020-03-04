using System;
using System.Collections.Generic;
using System.Text;

namespace TeamOrganiser.Models
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Defender { get; set; }
        public int Midfielder { get; set; }
        public int Attacker { get; set; }

    }
}
