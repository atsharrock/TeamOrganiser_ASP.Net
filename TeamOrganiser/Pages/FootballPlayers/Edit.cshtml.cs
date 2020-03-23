using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models;

namespace TeamOrganiser
{
    public class EditFootballPlayersModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public EditFootballPlayersModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FootballPlayer FootballPlayer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FootballPlayer = await _context.FootballPlayer.FirstOrDefaultAsync(m => m.ID == id);

            if (FootballPlayer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
          
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyFootballPlayer = new FootballPlayer();

            if (await TryUpdateModelAsync<FootballPlayer>(
                emptyFootballPlayer,
                "footballplayer",   // Prefix for form value.
                s => s.Name, s => s.Email, s => s.Defender, s => s.Midfielder, s => s.Attacker).ConfigureAwait(false))
            {
                _context.FootballPlayer.Add(emptyFootballPlayer);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }

            return null;
        }

        private bool FootballPlayerExists(int id)
        {
            return _context.FootballPlayer.Any(e => e.ID == id);
        }
    }
}
