using System;
using System.Collections.Generic;
using System.Text;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Models.Teams
{
    public interface ITeam
    {
        List<Player> PlayerList { get; set; }
        int TeamRating { get; }
    }
}
