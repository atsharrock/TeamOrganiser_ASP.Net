﻿using Microsoft.AspNetCore.Components;
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
        [Inject] FootballTeamService FootballTeamService { get; set; }
        [TestMethod]
        public void CreateFootballTeamTest()
        {
            List<FootballPlayer> TeamOneList = GenerateFootballPlayers().Take(5).ToList();
            List<FootballPlayer> TeamTwoList = Enumerable.Reverse(GenerateFootballPlayers()).Take(5).ToList();

            FootballTeam TeamOne = FootballTeamService.CreateTeam(TeamOneList);
            FootballTeam TeamTwo = FootballTeamService.CreateTeam(TeamTwoList);

            Assert.IsNotNull(TeamOne);
            Assert.IsTrue(TeamOne.FootballPlayers.Count == 5);
            Assert.IsTrue(TeamOne.TeamRating >= 0 && TeamOne.TeamRating <= 100);
            Assert.IsTrue(TeamOne.TeamChemistryRating >= 0 && TeamOne.TeamChemistryRating <= 100);

            Assert.IsNotNull(TeamTwo);
            Assert.IsTrue(TeamTwo.FootballPlayers.Count == 5);
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
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
                new FootballPlayer()
                {
                    Defence = rnd.Next(1, 101),
                    Midfield = rnd.Next(1, 101),
                    Forward = rnd.Next(1, 101)
                },
            };

            return output;
        }
    }
}
