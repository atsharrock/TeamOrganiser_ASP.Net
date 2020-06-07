using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Data
{
    public class TeamOrganiserContext : DbContext
    {
        public TeamOrganiserContext (DbContextOptions<TeamOrganiserContext> options)
            : base(options)
        {
        }

        public DbSet<TeamOrganiser.Models.Football.FootballGame> FootballGame { get; set; }
    }
}
