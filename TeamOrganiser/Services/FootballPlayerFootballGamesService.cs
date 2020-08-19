using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamOrganiser.Data;
using TeamOrganiser.Data.Entities.Football;
using TeamOrganiser.Models;

namespace TeamOrganiser.Services
{
    public class FootballPlayerFootballGamesService
    {
        private ApplicationDbContext _context;

        public FootballPlayerFootballGamesService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task LinkPlayersToFootballGame(List<FootballPlayer> players, int FootballGameId)
        {
            foreach (FootballPlayer p in players)
            {
                FootballPlayerFootballGames playerGame = new FootballPlayerFootballGames()
                {
                    FootballPlayerId = p.Id,
                    FootballGameId = FootballGameId
                };

                _context.FootballPlayerFootballGames.Add(playerGame);
            }

            await _context.SaveChangesAsync();
        }
    }
}
