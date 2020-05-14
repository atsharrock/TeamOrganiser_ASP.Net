using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Models.Account;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TeamOrganiser.Models.Account.UserAccount> UserAccount { get; set; }
        public DbSet<TeamOrganiser.Models.FootballPlayer> FootballPlayer { get; set; }
        public DbSet<TeamOrganiser.Models.Players.Player> Player { get; set; }

        public ApplicationDbContext()
        {

        }
    }
}
