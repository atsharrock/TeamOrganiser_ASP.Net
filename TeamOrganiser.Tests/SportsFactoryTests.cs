using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            //var player = SportsFactory.CreateSportsPerson(new FootballPlayer());

            //Assert.IsNotNull(player);
        }

        [TestMethod]
        public void CreatePlayerTest()
        {
            Player NewPlayer = new Player()
            {
                FirstName = "Andrew",
                LastName = "Sharrock",
                Email = "atsharrock@yahoo.co.uk",
                ContactNumber = null,
                Football = true
            };

            Assert.IsNotNull(NewPlayer);
            Assert.IsTrue(NewPlayer.Football);
            Assert.IsFalse(NewPlayer.Basketball);

        }
    }
}
