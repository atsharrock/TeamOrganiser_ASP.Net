using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Pages.FootballGames
{
    public class EditModel : PageModel
    {
        private readonly TeamOrganiser.Data.TeamOrganiserContext _context;

        public EditModel(TeamOrganiser.Data.TeamOrganiserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FootballGame FootballGame { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FootballGame = await _context.FootballGame.FirstOrDefaultAsync(m => m.Id == id);

            if (FootballGame == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FootballGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootballGameExists(FootballGame.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FootballGameExists(int id)
        {
            return _context.FootballGame.Any(e => e.Id == id);
        }
    }
}
