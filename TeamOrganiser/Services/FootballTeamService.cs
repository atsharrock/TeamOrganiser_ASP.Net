using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Services
{
    public class FootballTeamService
    {
        public FootballTeam CreateTeam(List<FootballPlayer> players)
        {
            FootballTeam team = new FootballTeam()
            {
                FootballPlayers = players,
                TeamRating = GetTeamRating(players),
                TeamChemistryRating = TeamChemistry.SetFootballChemistry(players)
            };

            return team;
        }

        private int GetTeamRating(List<FootballPlayer> playerList)
        {
            int Rating = 0;
            foreach (Player P in playerList)
            {
                Rating += P.Rating;
            }
            return Rating / playerList.Count;
        }
    }
}
