using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Models.Teams
{
    public class Team : ITeam
    {
        [Key]
        public int Id { get; set; }
        public List<Player> PlayerList { get; set; }
        public int TeamRating { get; private set; }

        public Team(List<Player> playerList)
        {
            if (playerList != null && playerList.Count > 4)
            {
                PlayerList = playerList;
                TeamRating = GetTeamRating(playerList);
            }
            else throw new ArgumentException();
            
        }

        private int GetTeamRating(List<Player> playerList)
        {
            int Rating = 0;
            foreach (Player P in playerList)
            {
                Rating += P.Rating;
            }
            return Rating / playerList.Count;
        }

        public Team()
        {

        }
    }
}
