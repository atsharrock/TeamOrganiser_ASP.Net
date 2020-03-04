using System;
using System.Collections.Generic;
using TeamOrganiser.Models;

namespace TeamOrganiser.Services
{
    public interface IFootballPlayerRepository
    {
        IEnumerable<FootballPlayer> GetAllFootballPlayers();
    }
}
