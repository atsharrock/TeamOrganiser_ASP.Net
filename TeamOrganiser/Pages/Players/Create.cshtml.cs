using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamOrganiser.Data;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser
{
    public class CreatePlayersModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public CreatePlayersModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; }

        public async Task<IActionResult> OnPostAsync(Player Player)
        {
            if (!ModelState.IsValid)
            {
                return Content("Error - Model state is invalid.");
            }

            if (Player != null)
            {
                Player NewPlayer = SportsFactory.CreatePlayer(Player);
                _context.Players.Add(NewPlayer);

                if (Player.Football)
                {
                    FootballPlayer NewFootballPlayer = SportsFactory.CreateFootballPlayer(NewPlayer);
                    _context.FootballPlayers.Add(NewFootballPlayer);
                }

                await _context.SaveChangesAsync().ConfigureAwait(true);

                return Content(NewPlayer.FirstName + " has been created!");
            }

            return Content("Error - Could not create Player.");
        }
    }
}
