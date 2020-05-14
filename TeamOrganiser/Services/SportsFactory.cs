using System;
using System.Threading.Tasks;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser
{
    public static class SportsFactory
    {

        public static Player CreatePlayer(Player Player)
        {
            Player NewPlayer = new Player();

            NewPlayer.FirstName = Player.FirstName;
            NewPlayer.LastName = Player.LastName;
            NewPlayer.Email = Player.Email;
            NewPlayer.ContactNumber = Player.ContactNumber;
            NewPlayer.Football = Player.Football;
            NewPlayer.Hockey = Player.Hockey;
            NewPlayer.Basketball = Player.Basketball;

            return NewPlayer;
        }

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
