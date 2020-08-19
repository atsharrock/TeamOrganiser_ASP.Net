using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamOrganiser.Data;
using TeamOrganiser.Data.Entities.Football;
using TeamOrganiser.Models;

namespace TeamOrganiser.Services
{
    public class FootballPlayerFootballTeamsService
    {
        private ApplicationDbContext _context;

        public FootballPlayerFootballTeamsService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task LinkPlayersToFootballTeam(List<FootballPlayer> players, int FootballTeamId)
        {
            foreach (FootballPlayer p in players)
            {
                FootballPlayerFootballTeams playerTeam = new FootballPlayerFootballTeams()
                {
                    FootballPlayerId = p.Id,
                    FootballTeamId = FootballTeamId
                };

                _context.FootballPlayerFootballTeams.Add(playerTeam);
            }

            await _context.SaveChangesAsync();
        }
    }
}
