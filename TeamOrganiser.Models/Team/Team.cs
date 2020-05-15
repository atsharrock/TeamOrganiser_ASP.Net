using System;
using System.Collections.Generic;
using System.Text;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Models.Team
{
    public class Team : ITeam
    {
        public List<IPlayer> PlayerList { get; set; }

        public Team(List<IPlayer> playerList)
        {
            PlayerList = playerList;
        }
    }
}
