using System;
using System.Collections.Generic;
using System.Text;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Models.Team
{
    public interface ITeam
    {
        List<IPlayer> PlayerList { get; set; }
    }
}
