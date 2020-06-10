using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Models.Account;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<FootballPlayer> FootballPlayer { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<FootballGame> FootballGame { get; set; }

        public ApplicationDbContext()
        {

        }

        
    }
}
