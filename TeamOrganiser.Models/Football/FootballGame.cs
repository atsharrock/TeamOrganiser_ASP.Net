using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamOrganiser.Models.Teams;

namespace TeamOrganiser.Models.Football
{
    public class FootballGame
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<FootballPlayer> FootballPlayers { get; set; }
        public virtual ICollection<Team> FootballTeams { get; set; }
        public string Address { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public Team Winner { get; set; }
    }
}
