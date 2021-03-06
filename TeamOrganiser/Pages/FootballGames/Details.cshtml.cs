﻿using System;
using System.Collections.Generic;
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
    public class DetailsModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public DetailsModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public FootballGame FootballGame { get; set; }
        public FootballTeam TeamA { get; set; }
        public FootballTeam TeamB { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FootballGame = await _context.FootballGames
                .Include(f => f.FootballTeams)
                .Include(f => f.FootballPlayers)
                .FirstOrDefaultAsync(m => m.Id == id);

            TeamA = FootballGame.FootballTeams.ToArray()[0];
            TeamB = FootballGame.FootballTeams.ToArray()[1];

            if (FootballGame == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
