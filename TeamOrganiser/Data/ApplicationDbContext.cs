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
using TeamOrganiser.Data.Entities.Football;

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
        public DbSet<FootballPlayerFootballGames> FootballPlayerFootballGames { get; set; }
        public DbSet<FootballPlayerFootballTeams> FootballPlayerFootballTeams { get; set; }

        public async void Seed()
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

                await Players.AddAsync(Andrew);
                await Players.AddAsync(Stuart);
                await Players.AddAsync(Jim);
                await Players.AddAsync(Gill);
                await Players.AddAsync(Stevie);
                await Players.AddAsync(Carly);
                await Players.AddAsync(Timme);
                await Players.AddAsync(Pete);
                await Players.AddAsync(Paul);
                await Players.AddAsync(Leeroy);

                SaveChanges();

            }

            if (!FootballPlayers.Any())
            {
                Random rnd = new Random();

                var Andrew = new FootballPlayer()
                {
                    FirstName = "Andrew",
                    LastName = "Sharrock",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var Stuart = new FootballPlayer()
                {
                    FirstName = "Stuart",
                    LastName = "Sharrock",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var Jim = new FootballPlayer()
                {
                    FirstName = "Jim",
                    LastName = "Sharrock",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var Gill = new FootballPlayer()
                {
                    FirstName = "Gill",
                    LastName = "Sharrock",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var Stevie = new FootballPlayer()
                {
                    FirstName = "Stevie",
                    LastName = "Sharrock",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var Carly = new FootballPlayer()
                {
                    FirstName = "Carly",
                    LastName = "Richardson",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var Timme = new FootballPlayer()
                {
                    FirstName = "Timme",
                    LastName = "Martin",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                }; ;
                var Pete = new FootballPlayer()
                {
                    FirstName = "Pete",
                    LastName = "Skipp",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var Paul = new FootballPlayer()
                {
                    FirstName = "Paul",
                    LastName = "French",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var Leeroy = new FootballPlayer()
                {
                    FirstName = "Leeroy",
                    LastName = "Jenkins",
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };

                Andrew.SetRating(); Stuart.SetRating(); Jim.SetRating(); Gill.SetRating(); Stevie.SetRating();
                Carly.SetRating(); Timme.SetRating(); Pete.SetRating(); Paul.SetRating(); Leeroy.SetRating();

                await FootballPlayers.AddAsync(Andrew);
                await FootballPlayers.AddAsync(Stuart);
                await FootballPlayers.AddAsync(Jim);
                await FootballPlayers.AddAsync(Gill);
                await FootballPlayers.AddAsync(Stevie);
                await FootballPlayers.AddAsync(Carly);
                await FootballPlayers.AddAsync(Timme);
                await FootballPlayers.AddAsync(Pete);
                await FootballPlayers.AddAsync(Paul);
                await FootballPlayers.AddAsync(Leeroy);

                SaveChanges();
            }
        }

    }
}
