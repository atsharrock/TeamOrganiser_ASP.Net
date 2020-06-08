using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void SetPlayerRatingTest()
        {

            FootballPlayer FootyPlayer = GenerateFootballPlayers()[0];
            int rating = FootyPlayer.SetRating();
            Assert.IsNotNull(rating);
            Assert.IsTrue(rating <= 100 && rating >= 0);

            var FootyPlayer2 = new FootballPlayer()
            {
                FirstName = "Player",
                LastName = "Two",
                Defence = 56,
                Midfield = 80,
                Forward = 90
            };

            int expectedRating = (FootyPlayer2.Defence + FootyPlayer2.Midfield + FootyPlayer2.Forward) / 3;
            int actualRating = FootyPlayer2.SetRating();
            Assert.AreEqual(expectedRating, actualRating);

        }

        [TestMethod]
        public void GetTopPositionsTest()
        {
            FootballPlayer FootyPlayer = GenerateFootballPlayers()[0];

            Dictionary<string, int> TopPositions = FootyPlayer.GetTopPositions();

            Assert.IsNotNull(TopPositions);
            Assert.IsTrue(TopPositions.Count == 3);
            Assert.IsTrue(TopPositions.First().Value >= TopPositions.Last().Value);
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
