using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Models.Teams;
using TeamOrganiser.Services;

namespace TeamOrganiser.Tests
{
    [TestClass]
    public class FootballTeamSorterTests
    {
        [TestMethod]
        public void CreateTeamsByAlternatingTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateTeamsByAlternating(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[1].PlayerList.Count == 5);
        }

        [TestMethod]
        public void CreateTeamsByEveryTwoTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateTeamsByEveryTwo(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[1].PlayerList.Count == 5);
        }

        [TestMethod]
        public void CreateTeamsByPointSystemTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateTeamsByPointSystem(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[1].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[0].TeamRating >= 0 && SortedTeams[0].TeamRating <= 100);
        }

        [TestMethod]
        public void CreateTeamsBySkillBucketsTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateTeamsBySkillBuckets(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[1].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[0].TeamRating >= 0 && SortedTeams[0].TeamRating <= 100);
        }

        [TestMethod]
        public void CreateFairTeamsTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateFairTeams(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[1].PlayerList.Count == 5);
            Assert.IsTrue(SortedTeams[0].TeamRating >= 0 && SortedTeams[0].TeamRating <= 100);
        }

        private List<FootballPlayer> GenerateFootballPlayers()
        {
            List<FootballPlayer> output = new List<FootballPlayer>()
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
