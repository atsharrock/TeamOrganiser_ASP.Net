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
            var player = SportsFactory.createSportsPerson(new FootballPlayer());

            Assert.IsNotNull(player);
        }
    }
}
