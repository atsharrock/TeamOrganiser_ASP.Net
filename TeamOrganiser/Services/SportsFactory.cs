using System;
using System.Threading.Tasks;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser
{
    public static class SportsFactory
    {

        public static FootballPlayer CreateFootballPlayer(Player player)
        {
            if (null == player)
            {
                throw new System.ArgumentException("Player does not exist");
            }

            FootballPlayer NewFootballPlayer = new FootballPlayer()
            {
                ID = player.ID,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Email = player.Email,
                ContactNumber = player.ContactNumber
            };

            return NewFootballPlayer;
        }

    }
}
