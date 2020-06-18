using System;
using System.Collections.Generic;
using System.Text;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Models.Teams
{
    public interface ITeam
    {
        int TeamRating { get; set; }
        int TeamChemistryRating { get; set; }
        int GamesPlayed { get; set; }
        int GamesWon { get; set; }
        int GamesLost { get; set; }
    }
}
