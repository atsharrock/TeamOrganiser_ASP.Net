using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models;

namespace TeamOrganiser
{
    public class DeleteFootballPlayersModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public DeleteFootballPlayersModel(TeamOrganiser.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FootballPlayer = await _context.FootballPlayer.FindAsync(id);

            if (FootballPlayer != null)
            {
                _context.FootballPlayer.Remove(FootballPlayer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
