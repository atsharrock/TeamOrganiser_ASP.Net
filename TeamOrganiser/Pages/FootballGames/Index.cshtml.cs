using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Pages.FootballGames
{
    public class IndexModel : PageModel
    {
        private readonly TeamOrganiser.Data.TeamOrganiserContext _context;

        public IndexModel(TeamOrganiser.Data.TeamOrganiserContext context)
        {
            _context = context;
        }

        public IList<FootballGame> FootballGame { get;set; }

        public async Task OnGetAsync()
        {
            FootballGame = await _context.FootballGame.ToListAsync();
        }
    }
}
