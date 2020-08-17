using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeamOrganiser.Models.Teams;

namespace TeamOrganiser.Models.Football
{
    public class FootballTeam : ITeam
    {
        [Key]
        public int Id { get; set; }
        public int TeamChemistryRating { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesLost { get; set; }
        public int TeamRating { get; set; }
        public int GamesWon { get; set; }

        public virtual ICollection<FootballPlayer> FootballPlayers { get; set; }
    }
}
