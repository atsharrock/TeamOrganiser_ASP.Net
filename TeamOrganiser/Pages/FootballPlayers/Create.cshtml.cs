using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamOrganiser.Data;
using TeamOrganiser.Models;

namespace TeamOrganiser
{
    public class CreateFootballPlayersModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public CreateFootballPlayersModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FootballPlayer FootballPlayer { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FootballPlayer.Add(FootballPlayer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
