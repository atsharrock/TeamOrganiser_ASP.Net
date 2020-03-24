﻿using System;
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
    public class IndexFootballPlayersModel : PageModel
    {
        private readonly TeamOrganiser.Data.ApplicationDbContext _context;

        public IndexFootballPlayersModel(TeamOrganiser.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FootballPlayer> FootballPlayer { get;set; }

        public async Task OnGetAsync()
        {
            FootballPlayer = await _context.FootballPlayer.ToListAsync();
        }
    }
}