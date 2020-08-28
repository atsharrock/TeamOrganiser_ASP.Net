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
    public class EditFootballersModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public EditFootballersModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                // insert error handling
            }

            var FootballPlayer = await _context.FootballPlayers.FindAsync(id);

            if (FootballPlayer == null)
            {
                // insert error handling
            }

            return new JsonResult(FootballPlayer);
        }

        public async Task<IActionResult> OnPostAsync(FootballPlayer FootballPlayer)
        {
            FootballPlayer FootballPlayerToUpdate = await _context.FootballPlayers.FirstOrDefaultAsync(m => m.Id == FootballPlayer.Id).ConfigureAwait(false);

            if (null == FootballPlayerToUpdate)
            {
                return Content("Error - Football player does not exist.");
            }

            FootballPlayerToUpdate.CentreBack = FootballPlayer.CentreBack;
            FootballPlayerToUpdate.Sweeper = FootballPlayer.Sweeper;
            FootballPlayerToUpdate.FullBack = FootballPlayer.FullBack;
            FootballPlayerToUpdate.WingBack = FootballPlayer.WingBack;
            FootballPlayerToUpdate.CentreMidfield = FootballPlayer.CentreMidfield;
            FootballPlayerToUpdate.DefensiveMidfield = FootballPlayer.DefensiveMidfield;
            FootballPlayerToUpdate.AttackingMidfield = FootballPlayer.AttackingMidfield;
            FootballPlayerToUpdate.WideMidfield = FootballPlayer.WideMidfield;
            FootballPlayerToUpdate.Forward = FootballPlayer.Forward;
            FootballPlayerToUpdate.CentreForward = FootballPlayer.CentreForward;
            FootballPlayerToUpdate.Winger = FootballPlayer.Winger;
            FootballPlayerToUpdate.SetRating();

            int result = await _context.SaveChangesAsync().ConfigureAwait(false);

            if (result == 1)
            {
                return Content($"{FootballPlayerToUpdate.Player.FirstName} has been updated!");
            }

            return Content("Error - please contact your system administrator");

        }
    }
}
