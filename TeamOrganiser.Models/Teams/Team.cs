using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Models.Teams
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public int TeamRating { get; set; }
        public int TeamChemistryRating { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }

    }
}
