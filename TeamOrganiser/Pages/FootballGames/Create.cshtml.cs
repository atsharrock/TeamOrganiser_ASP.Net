using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamOrganiser.Data;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Services;

namespace TeamOrganiser.Pages.FootballGames
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private FootballTeamSorter _footballTeamSorter { get; set; }
        private FootballTeamService _footballTeamService { get; set; }
        private FootballPlayerFootballGamesService _playerGamesService { get; set; }
        private FootballPlayerFootballTeamsService _playerTeamsService { get; set; }
        private UserManager<IdentityUser> _userManager { get; set; }

        public CreateModel(TeamOrganiser.Data.ApplicationDbContext context, 
            FootballTeamSorter footballTeamSorter,
            FootballTeamService footballTeamService,
            FootballPlayerFootballGamesService footballPlayerFootballGamesService,
            FootballPlayerFootballTeamsService footballPlayerFootballTeamsService,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _footballTeamSorter = footballTeamSorter;
            _footballTeamService = footballTeamService;
            _playerGamesService = footballPlayerFootballGamesService;
            _playerTeamsService = footballPlayerFootballTeamsService;
            _userManager = userManager;
            AllFootballPlayers = _context.FootballPlayers.ToList();
        }

        public IActionResult OnGet()
        {
            DateTime = DateTime.Now;
            return Page();
        }

        [BindProperty] public FootballGame FootballGame { get; set; }

        [BindProperty] public DateTime DateTime { get; set; }

        [BindProperty] public TimeSpan StartTime { get; set; }

        [BindProperty] public TimeSpan EndTime { get; set; }

        [BindProperty] public List<int> SelectedPlayers { get; set; }

        public List<FootballPlayer> AllFootballPlayers { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || SelectedPlayers.Count() == 0 || StartTime == EndTime)
            {
                return Page();
            }

            FootballGame.StartTime = DateTime + StartTime;
            FootballGame.EndTime = DateTime + EndTime;

            TimeSpan duration = EndTime - StartTime;
            FootballGame.Duration = duration.Hours;

            foreach (FootballPlayer p in AllFootballPlayers)
            {
                if(SelectedPlayers.Contains(p.Id))
                {
                    FootballGame.FootballPlayers.Add(p);
                }
            }

            IdentityUser User = await _userManager.GetUserAsync(HttpContext.User);
            FootballGame.IdentityUserId = Guid.Parse(User.Id);

            List<FootballTeam> Teams = _footballTeamSorter.CreateFairTeams(FootballGame.FootballPlayers.ToList());
            FootballTeam TeamA = await _footballTeamService.SaveFootballTeam(Teams[0]);
            FootballTeam TeamB = await _footballTeamService.SaveFootballTeam(Teams[1]);
            FootballGame.FootballTeams.Add(TeamA);
            FootballGame.FootballTeams.Add(TeamB);

            _context.FootballGames.Add(FootballGame);
            await _context.SaveChangesAsync();

            await _playerGamesService.LinkPlayersToFootballGame(FootballGame.FootballPlayers.ToList(), FootballGame.Id);
            await _playerTeamsService.LinkPlayersToFootballTeam(TeamA.FootballPlayers.ToList(), TeamA.Id);
            await _playerTeamsService.LinkPlayersToFootballTeam(TeamB.FootballPlayers.ToList(), TeamB.Id);

            return RedirectToPage("./Index");
        }
        
    }
}
