using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Team;
using TeamOrganiser.Services;

namespace TeamOrganiser.Tests
{
    [TestClass]
    public class TeamSorterTests
    {
        [TestMethod]
        public void CreateTeamsByAlternatingTest()
        {
            List<Team> SortedTeams = TeamSorter.CreateTeamsByAlternating(GenerateFootballPlayers(), "Football");

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[1].PlayerList.Count == 5);
        }

        [TestMethod]
        public void CreateTeamsByEveryTwoTest()
        {
            List<Team> SortedTeams = TeamSorter.CreateTeamsByEveryTwo(GenerateFootballPlayers(), "Football");

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[1].PlayerList.Count == 5);
        }

        private List<IPlayer> GenerateFootballPlayers()
        {
            List<IPlayer> output = new List<IPlayer>()
            {
                new FootballPlayer()
                {
                    FirstName = "Andrew",
                    LastName = "Sharrock",
                    Rating = 10,
                },
                new FootballPlayer()
                {
                    FirstName = "Stuart",
                    LastName = "Sharrock",
                    Rating = 20,
                },
                new FootballPlayer()
                {
                    FirstName = "Jim",
                    LastName = "Sharrock",
                    Rating = 30,
                },
                new FootballPlayer()
                {
                    FirstName = "Gill",
                    LastName = "Sharrock",
                    Rating = 40,
                },
                new FootballPlayer()
                {
                    FirstName = "Stevie",
                    LastName = "Sharrock",
                    Rating = 50,
                },
                new FootballPlayer()
                {
                    FirstName = "Carly",
                    LastName = "Richardson",
                    Rating = 60,
                },
                new FootballPlayer()
                {
                    FirstName = "Timme",
                    LastName = "Martin",
                    Rating = 70,
                },
                new FootballPlayer()
                {
                    FirstName = "Pete",
                    LastName = "Skipp",
                    Rating = 80,
                },
                new FootballPlayer()
                {
                    FirstName = "Paul",
                    LastName = "French",
                    Rating = 90,
                },
                new FootballPlayer()
                {
                    FirstName = "Leeroy",
                    LastName = "Jenkins",
                    Rating = 100,
                },
            };

            return output;
        }
    }
}
