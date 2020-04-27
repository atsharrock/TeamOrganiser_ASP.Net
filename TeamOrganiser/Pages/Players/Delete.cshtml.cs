using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser
{
    public class DeleteModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public DeleteModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; }

        public async Task<JsonResult> OnGetAsync(int? id)
        {
            Player Player = await _context.Player.FindAsync(id);

            if (Player == null)
            {
                // insert error handling
            }

            return new JsonResult(Player);
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player Player = await _context.Player
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.ID == id).ConfigureAwait(false);

            if (Player == null)
            {
                return NotFound();
            }

            try
            {
                _context.Player.Remove(Player);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Content(Player.FirstName + " successfully deleted!");
            }
            catch (DbUpdateException)
            {
                return Content("Error");
            }
        }
    }
}
