﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Teams;
using TeamOrganiser.Services;

namespace TeamOrganiser.Tests
{
    [TestClass]
    public class ChemistryTests
    {
        [TestMethod]
        public void GetTeamChemistryTest()
        {
            List<FootballPlayer> players = GenerateFootballPlayers().Take(5).ToList();
            int chemistry = TeamChemistry.SetFootballChemistry(players);

            Assert.IsNotNull(chemistry);
            Assert.AreNotEqual(0, chemistry); // Chemistry should never be zero.
            Assert.IsTrue(chemistry >= 0 && chemistry <= 100);
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
