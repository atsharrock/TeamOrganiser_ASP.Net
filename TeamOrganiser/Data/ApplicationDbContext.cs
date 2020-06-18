using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamOrganiser.Models.Account;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Football;
using Microsoft.EntityFrameworkCore.Internal;

namespace TeamOrganiser.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<FootballPlayer> FootballPlayers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<FootballGame> FootballGames { get; set; }
        public DbSet<FootballTeam> FootballTeams { get; set; }

        public void Seed()
        {
            if (!Players.Any())
            {
                var Andrew = new Player()
                {
                    FirstName = "Andrew",
                    LastName = "Sharrock",
                    Football = true,
                };
                var Stuart = new Player()
                {
                    FirstName = "Stuart",
                    LastName = "Sharrock",
                    Football = true,
                };
                var Jim = new Player()
                {
                    FirstName = "Jim",
                    LastName = "Sharrock",
                    Football = true,
                };
                var Gill = new Player()
                {
                    FirstName = "Gill",
                    LastName = "Sharrock",
                    Football = true,
                };
                var Stevie = new Player()
                {
                    FirstName = "Stevie",
                    LastName = "Sharrock",
                    Football = true,
                };
                var Carly = new Player()
                {
                    FirstName = "Carly",
                    LastName = "Richardson",
                    Football = true,
                };
                var Timme = new Player()
                {
                    FirstName = "Timme",
                    LastName = "Martin",
                    Football = true,
                };
                var Pete = new Player()
                {
                    FirstName = "Pete",
                    LastName = "Skipp",
                    Football = true,
                };
                var Paul = new Player()
                {
                    FirstName = "Paul",
                    LastName = "French",
                    Football = true,
                };
                var Leeroy = new Player()
                {
                    FirstName = "Leeroy",
                    LastName = "Jenkins",
                    Football = true,
                };

                Players.Add(Andrew); Players.Add(Stuart); Players.Add(Jim); Players.Add(Gill); Players.Add(Stevie);
                Players.Add(Carly); Players.Add(Timme); Players.Add(Pete); Players.Add(Paul); Players.Add(Leeroy);
            }

            Random rnd = new Random();

            List<FootballPlayer> output = new List<FootballPlayer>()
            {
                new FootballPlayer()
                {
                    FirstName = "Andrew",
                    LastName = "Sharrock",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Stuart",
                    LastName = "Sharrock",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Jim",
                    LastName = "Sharrock",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Gill",
                    LastName = "Sharrock",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Stevie",
                    LastName = "Sharrock",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Carly",
                    LastName = "Richardson",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Timme",
                    LastName = "Martin",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Pete",
                    LastName = "Skipp",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Paul",
                    LastName = "French",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    FirstName = "Leeroy",
                    LastName = "Jenkins",
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
            };

        }

    }
}
