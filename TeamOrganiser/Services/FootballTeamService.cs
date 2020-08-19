using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Data;
using Microsoft.AspNetCore.Components;

namespace TeamOrganiser.Services
{
    public class FootballTeamService
    {
        private ApplicationDbContext _context;

        public FootballTeamService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

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

        public async Task<FootballTeam> SaveFootballTeam(FootballTeam team)
        {
            _context.FootballTeams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        private int GetTeamRating(List<FootballPlayer> playerList)
        {
            int Rating = 0;
            foreach (FootballPlayer P in playerList)
            {
                Rating += P.Rating;
            }
            return Rating / playerList.Count;
        }
    }
}
