using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamOrganiser.Data;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Services;

namespace TeamOrganiser.Pages.FootballGames
{
    public class CreateModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public CreateModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
            AllFootballPlayers = _context.FootballPlayers.ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FootballGame FootballGame { get; set; }

        [BindProperty]
        public List<int> SelectedPlayers { get; set; }

        public List<FootballPlayer> AllFootballPlayers { get; set; }

        [Inject]
        FootballTeamService FootballTeamService { get; set; }

        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (FootballPlayer p in AllFootballPlayers)
            {
                if(SelectedPlayers.Contains(p.Id))
                {
                    FootballGame.FootballPlayers.Add(p);
                }
            }

            List<FootballTeam> Teams = FootballTeamSorter.CreateFairTeams(FootballGame.FootballPlayers.ToList());
            FootballGame.FootballTeams.Add(Teams[0]);
            FootballGame.FootballTeams.Add(Teams[1]);

            _context.FootballGames.Add(FootballGame);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        
    }
}
