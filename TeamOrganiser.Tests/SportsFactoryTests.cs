using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Tests
{
    [TestClass]
    public class SportsFactoryTests
    {

        [TestMethod]
        public void CreateFootballPlayerTest()
        {

            Player NewPlayer = GeneratePlayers()[0];

            FootballPlayer footballPlayer = SportsFactory.CreateFootballPlayer(NewPlayer);

            Assert.IsNotNull(footballPlayer);
            Assert.AreEqual("Andrew", footballPlayer.FirstName);

        }

        [TestMethod]
        public void CreatePlayerTest()
        {
            Player Player = GeneratePlayers()[0];
            Player SportsFactoryPlayer = SportsFactory.CreatePlayer(Player);

            Assert.IsNotNull(SportsFactoryPlayer);
            Assert.AreEqual("Andrew", SportsFactoryPlayer.FirstName);
        }

        private List<Player> GeneratePlayers()
        {
            List<Player> output = new List<Player>()
            {
                new Player()
                {
                    FirstName = "Andrew",
                    LastName = "Sharrock",
                    Email = "A@S.com",
                    ContactNumber = "12345678",
                    Football = true,
                    Hockey = false,
                    Basketball = false
                },
                new Player()
                {
                    FirstName = "Timme",
                    LastName = "Martin",
                    Email = "T@M.com",
                    ContactNumber = "87654321",
                    Football = true,
                    Hockey = true,
                    Basketball = false
                }
            };

            return output;
        }

    }
}
