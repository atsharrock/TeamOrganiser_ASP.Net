using System;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser
{
    public static class SportsFactory
    {
        public static Player CreatePlayer(string firstName, string lastName, string email, string contactNumber,
                        bool football, bool hockey, bool basketball)
        {
            Player NewPlayer = new Player()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email ?? null,
                ContactNumber = contactNumber ?? null,
                Football = football,
                Hockey = hockey,
                Basketball = basketball
            };

            return NewPlayer;
        }

        public static IPlayer CreateSportsPerson(Player player, IPlayer sport)
        {
            if (null == player)
            {
                throw new System.ArgumentException("Player does not exist");
            }

            Type type = sport.GetType();

            if (type.Name.Equals("FootballPlayer"))
            {
                return new FootballPlayer();
            }

            throw new Exception();
        }

    }
}
