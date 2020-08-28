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
using TeamOrganiser.Models.Sports;

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
        public DbSet<Sport> Sports { get; set; }
        public DbSet<PlayerSports> PlayerSports { get; set; }
        public DbSet<FootballPlayerFootballGames> FootballPlayerFootballGames { get; set; }
        public DbSet<FootballPlayerFootballTeams> FootballPlayerFootballTeams { get; set; }

        public async void Seed()
        {
            Random rnd = new Random();

            if (!Players.Any() && !FootballPlayers.Any() && !Sports.Any())
            {

                Sport Football = new Football()
                {
                    Name = "Football"
                };
                Sports.Add(Football);

                var Andrew = new Player()
                {
                    FirstName = "Andrew",
                    LastName = "Sharrock",
                };
                var Stuart = new Player()
                {
                    FirstName = "Stuart",
                    LastName = "Sharrock",
                };
                var Jim = new Player()
                {
                    FirstName = "Jim",
                    LastName = "Sharrock",
                };
                var Gill = new Player()
                {
                    FirstName = "Gill",
                    LastName = "Sharrock",
                };
                var Stevie = new Player()
                {
                    FirstName = "Stevie",
                    LastName = "Sharrock",
                };
                var Carly = new Player()
                {
                    FirstName = "Carly",
                    LastName = "Richardson"
                };
                var Timme = new Player()
                {
                    FirstName = "Timme",
                    LastName = "Martin",
                };
                var Pete = new Player()
                {
                    FirstName = "Pete",
                    LastName = "Skipp",
                };
                var Paul = new Player()
                {
                    FirstName = "Paul",
                    LastName = "French",
                };
                var Leeroy = new Player()
                {
                    FirstName = "Leeroy",
                    LastName = "Jenkins",
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

                var AndrewFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Andrew.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var StuartFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Stuart.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var JimFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Jim.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var GillFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Gill.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var StevieFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Stevie.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var CarlyFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Carly.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var TimmeFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Timme.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                }; ;
                var PeteFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Pete.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var PaulFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Paul.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };
                var LeeroyFootballPlayer = new FootballPlayer()
                {
                    PlayerId = Leeroy.Id,
                    CentreBack = rnd.Next(1, 101),
                    CentreMidfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                };

                AndrewFootballPlayer.SetRating(); StuartFootballPlayer.SetRating(); JimFootballPlayer.SetRating(); 
                GillFootballPlayer.SetRating(); StevieFootballPlayer.SetRating(); CarlyFootballPlayer.SetRating(); 
                TimmeFootballPlayer.SetRating(); PeteFootballPlayer.SetRating(); PaulFootballPlayer.SetRating(); 
                LeeroyFootballPlayer.SetRating();

                await FootballPlayers.AddAsync(AndrewFootballPlayer);
                await FootballPlayers.AddAsync(StuartFootballPlayer);
                await FootballPlayers.AddAsync(JimFootballPlayer);
                await FootballPlayers.AddAsync(GillFootballPlayer);
                await FootballPlayers.AddAsync(StevieFootballPlayer);
                await FootballPlayers.AddAsync(CarlyFootballPlayer);
                await FootballPlayers.AddAsync(TimmeFootballPlayer);
                await FootballPlayers.AddAsync(PeteFootballPlayer);
                await FootballPlayers.AddAsync(PaulFootballPlayer);
                await FootballPlayers.AddAsync(LeeroyFootballPlayer);

                SaveChanges();

                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Andrew.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Stuart.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Jim.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Gill.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Stevie.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Carly.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Timme.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Pete.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Paul.Id,
                    SportId = Football.Id,
                });
                await PlayerSports.AddAsync(new PlayerSports()
                {
                    PlayerId = Leeroy.Id,
                    SportId = Football.Id,
                });


                SaveChanges();

            }

        }

    }
}
