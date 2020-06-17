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

            List<int> DefenceRatings = new List<int>() { FootballPlayerToUpdate.CentreBack, FootballPlayerToUpdate.Sweeper,
                                                            FootballPlayerToUpdate.FullBack, FootballPlayerToUpdate.WingBack };

            List<int> MidfieldRatings = new List<int>() { FootballPlayerToUpdate.CentreMidfield, FootballPlayerToUpdate.DefensiveMidfield,
                                                           FootballPlayerToUpdate.AttackingMidfield, FootballPlayerToUpdate.WideMidfield };

            List<int> AttackRatings = new List<int>() { FootballPlayerToUpdate.Forward, FootballPlayerToUpdate.CentreForward, FootballPlayerToUpdate.Winger };

            FootballPlayerToUpdate.Defence = GetPositionRating(DefenceRatings);
            FootballPlayerToUpdate.Midfield = GetPositionRating(MidfieldRatings);
            FootballPlayerToUpdate.Attack = GetPositionRating(AttackRatings);

            FootballPlayerToUpdate.Rating = GetOverallRating(FootballPlayerToUpdate.Defence, FootballPlayerToUpdate.Midfield, FootballPlayerToUpdate.Attack);

            int result = await _context.SaveChangesAsync().ConfigureAwait(false);

            if (result == 1)
            {
                return Content($"{FootballPlayerToUpdate.FirstName} has been updated!");
            }

            return Content("Error - please contact your system administrator");

        }

        private int GetOverallRating(int Defence, int Midfield, int Attack) 
        {
            return (Defence + Midfield + Attack) / 3;
        }

        private int GetPositionRating(List<int> PositionRatings)
        {
            int count = 0;
            int rating = 0;

            foreach (int position in PositionRatings)
            {
                if (position != 0)
                {
                    count++;
                    rating += position;
                }
            }

            if (count == 0)
            {
                return 0;
            }

            return rating / count;
        }

    }
}
