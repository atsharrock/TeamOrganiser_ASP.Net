using Microsoft.AspNetCore.Components;
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
        [Inject] private FootballTeamSorter FootballTeamSorter { get; set; }

        [TestMethod]
        public void CreateTeamsByAlternatingTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateTeamsByAlternating(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].FootballPlayers.Count == 5);
            Assert.IsTrue(SortedTeams[1].FootballPlayers.Count == 5);
        }

        [TestMethod]
        public void CreateTeamsByEveryTwoTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateTeamsByEveryTwo(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].FootballPlayers.Count == 5);
            Assert.IsTrue(SortedTeams[1].FootballPlayers.Count == 5);
        }

        [TestMethod]
        public void CreateTeamsByPointSystemTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateTeamsByPointSystem(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].FootballPlayers.Count == 5);
            Assert.IsTrue(SortedTeams[1].FootballPlayers.Count == 5);
            Assert.IsTrue(SortedTeams[0].TeamRating >= 0 && SortedTeams[0].TeamRating <= 100);
        }

        [TestMethod]
        public void CreateTeamsBySkillBucketsTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateTeamsBySkillBuckets(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].FootballPlayers.Count == 5);
            Assert.IsTrue(SortedTeams[1].FootballPlayers.Count == 5);
            Assert.IsTrue(SortedTeams[0].TeamRating >= 0 && SortedTeams[0].TeamRating <= 100);
        }

        [TestMethod]
        public void CreateFairTeamsTest()
        {
            List<FootballTeam> SortedTeams = FootballTeamSorter.CreateFairTeams(GenerateFootballPlayers());

            Assert.IsNotNull(SortedTeams);
            Assert.IsTrue(SortedTeams.Count == 2);
            Assert.IsTrue(SortedTeams[0].FootballPlayers.Count == 5);
            Assert.IsTrue(SortedTeams[1].FootballPlayers.Count == 5);
            Assert.IsTrue(SortedTeams[0].TeamRating >= 0 && SortedTeams[0].TeamRating <= 100);
        }

        private List<FootballPlayer> GenerateFootballPlayers()
        {
            List<FootballPlayer> output = new List<FootballPlayer>()
            {
                new FootballPlayer()
                {
                    Rating = 10,
                },
                new FootballPlayer()
                {
                    Rating = 20,
                },
                new FootballPlayer()
                {
                    Rating = 30,
                },
                new FootballPlayer()
                {
                    Rating = 40,
                },
                new FootballPlayer()
                {
                    Rating = 50,
                },
                new FootballPlayer()
                {
                    Rating = 60,
                },
                new FootballPlayer()
                {
                    Rating = 70,
                },
                new FootballPlayer()
                {
                    Rating = 80,
                },
                new FootballPlayer()
                {
                    Rating = 90,
                },
                new FootballPlayer()
                {
                    Rating = 100,
                },
            };

            return output;
        }
    }
}
