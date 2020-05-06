using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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

            Player NewPlayer = new Player()
            {
                FirstName = "Andrew",
                LastName = "Sharrock",
                Email = "atsharrock@yahoo.co.uk",
                ContactNumber = null,
                Football = true,
                Basketball = false,
                Hockey = false,
            };

            FootballPlayer footballPlayer = SportsFactory.CreateFootballPlayer(NewPlayer);

            Assert.IsNotNull(footballPlayer);
            Assert.AreEqual("Andrew", footballPlayer.FirstName);

        }

    }
}
