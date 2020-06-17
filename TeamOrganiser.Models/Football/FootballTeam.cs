using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeamOrganiser.Models.Teams;

namespace TeamOrganiser.Models.Football
{
    public class FootballTeam : Team
    {
        public virtual List<FootballPlayer> FootballPlayers { get; set; }

        public virtual ICollection<FootballGame> FootballGames { get; set; }
    }
}
