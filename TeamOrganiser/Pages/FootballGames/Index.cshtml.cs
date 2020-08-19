using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Data;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Pages.FootballGames
{
    public class IndexModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager { get; set; }

        public IndexModel(TeamOrganiser.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            FootballGame = new FootballGame();
        }

        public FootballGame FootballGame { get; set; }
        public IList<FootballGame> FootballGames { get;set; }

        public async Task OnGetAsync()
        {
            IdentityUser User = await _userManager.GetUserAsync(HttpContext.User);
            FootballGames = await _context.FootballGames
                .Where(g => g.IdentityUserId == Guid.Parse(User.Id)).ToListAsync();
        }
    }
}
