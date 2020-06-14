using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Services;

namespace TeamOrganiser.Tests.Football
{
    [TestClass]
    public class FootballTeamServiceTests
    {
        [TestMethod]
        public void CreateFootballTeamTest()
        {
            List<FootballPlayer> TeamOneList = GenerateFootballPlayers().Take(5).ToList();
            List<FootballPlayer> TeamTwoList = Enumerable.Reverse(GenerateFootballPlayers()).Take(5).ToList();

            FootballTeamService footballTeamService = new FootballTeamService();
            FootballTeam TeamOne = footballTeamService.CreateTeam(TeamOneList);
            FootballTeam TeamTwo = footballTeamService.CreateTeam(TeamTwoList);

            Assert.IsNotNull(TeamOne);
            Assert.IsTrue(TeamOne.PlayerList.Count == 5);
            Assert.IsTrue(TeamOne.TeamRating >= 0 && TeamOne.TeamRating <= 100);
            Assert.IsTrue(TeamOne.TeamChemistryRating >= 0 && TeamOne.TeamChemistryRating <= 100);

            Assert.IsNotNull(TeamTwo);
            Assert.IsTrue(TeamTwo.PlayerList.Count == 5);
            Assert.IsTrue(TeamTwo.TeamRating >= 0 && TeamTwo.TeamRating <= 100);
            Assert.IsTrue(TeamTwo.TeamChemistryRating >= 0 && TeamTwo.TeamChemistryRating <= 100);
        }

        private List<FootballPlayer> GenerateFootballPlayers()
        {
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

            return output;
        }
    }
}
