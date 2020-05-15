using System;
using System.Collections.Generic;
using System.Text;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Models.Team
{
    public class Team : ITeam
    {
        public List<IPlayer> PlayerList { get; set; }
        public int TeamRating { get; private set; }

        public Team(List<IPlayer> playerList)
        {
            if (playerList != null && playerList.Count > 4)
            {
                PlayerList = playerList;
                TeamRating = GetTeamRating(playerList);
            }
            else throw new ArgumentException();
            
        }

        private int GetTeamRating(List<IPlayer> playerList)
        {
            int Rating = 0;
            foreach (IPlayer P in playerList)
            {
                Rating += P.Rating;
            }
            return Rating / playerList.Count;
        }
    }
}
