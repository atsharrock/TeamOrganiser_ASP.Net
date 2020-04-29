using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamOrganiser.Data;
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

            Player NewPlayer = new Player();

            if (Player != null)
            {
                NewPlayer.FirstName = Player.FirstName;
                NewPlayer.LastName = Player.LastName;
                NewPlayer.Email = Player.Email;
                NewPlayer.ContactNumber = Player.ContactNumber;
                NewPlayer.Football = Player.Football;
                NewPlayer.Hockey = Player.Hockey;
                NewPlayer.Basketball = Player.Basketball;

                _context.Player.Add(NewPlayer);
                await _context.SaveChangesAsync().ConfigureAwait(true);

                if (Player.Football)
                {

                }

                if (Player.Hockey)
                {

                }

                if (Player.Basketball)
                {

                }

                return Content(NewPlayer.FirstName + " has been created!");
            }

            return Content("Error - Could not create Player.");
        }
    }
}
