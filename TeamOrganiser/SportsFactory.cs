using System;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser
{
    public static class SportsFactory
    {
        public static IPlayer createSportsPerson(IPlayer player)
        {
            if (null == player)
            {
                throw new System.ArgumentException("Player does not exist");
            }
            Type type = player.GetType();

            if (type.Name.Equals("FootballPlayer"))
            {
                return new FootballPlayer();
            }

            throw new Exception();
        }
    }
}
