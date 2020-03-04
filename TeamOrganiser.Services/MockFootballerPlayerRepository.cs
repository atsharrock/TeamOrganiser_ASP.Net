﻿using System;
using System.Collections.Generic;
using System.Text;
using TeamOrganiser.Models;

namespace TeamOrganiser.Services
{
    public class MockFootballerPlayerRepository : IFootballPlayerRepository
    {
        private List<FootballPlayer> _FootballPlayerList;

        public MockFootballerPlayerRepository()
        {
            _FootballPlayerList = new List<FootballPlayer>()
            {
                new FootballPlayer() { Id = 1, Name = "Andy", Email = "Me@email.com" },
                new FootballPlayer() { Id = 2, Name = "Timme", Email = "Timme@email.com" },
                new FootballPlayer() { Id = 3, Name = "Pete", Email = "Pete@email.com" }
            };
        }

        public IEnumerable<FootballPlayer> GetAllFootballPlayers()
        {
            return _FootballPlayerList;
        }
    }
}
