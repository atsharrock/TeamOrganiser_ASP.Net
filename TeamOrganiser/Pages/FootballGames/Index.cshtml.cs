using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Pages.FootballGames
{
    public class IndexModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public IndexModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
            FootballGame = new FootballGame();
        }

        public FootballGame FootballGame { get; set; }
        public IList<FootballGame> FootballGames { get;set; }
        public List<FootballPlayer> AllFootballPlayers { get; set; }

        public async Task OnGetAsync()
        {
            FootballGames = await _context.FootballGames.ToListAsync();
            AllFootballPlayers = await _context.FootballPlayers.ToListAsync();
        }
    }
}
