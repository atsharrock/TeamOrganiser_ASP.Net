﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Team;

namespace TeamOrganiser.Services
{
    ///<summary>
    /// The TeamSorter class sorts players into two groups
    /// of fair teams. Teams can be sorted randomly,
    /// based on their ratings or form.
    ///</summary>
    public static class TeamSorter
    {
        ///<summary>
        /// Teams are assigned a player one after the other in order of rating.
        ///</summary>
        public static List<Team> CreateTeamsByAlternating(List<IPlayer> players, string sport)
        {
            List<IPlayer> playerscopy = new List<IPlayer>(players);
            switch (sport)
            {
                case "Football":
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
                default:
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
            }

            List<IPlayer> listTeamA = new List<IPlayer>();
            List<IPlayer> listTeamB = new List<IPlayer>();

            for (int i = 0; i < playerscopy.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    listTeamA.Add(players[i]);
                }
                else
                {
                    listTeamB.Add(players[i]);
                }
            }

            Team teamA = new Team(listTeamA);
            Team teamB = new Team(listTeamB);

            return new List<Team>() { teamA, teamB };
        }

        ///<summary>
        /// Teams are sorted by giving one team the best player. The next team
        /// get the next two best players and so on until there are no players left.
        ///</summary>
        public static List<Team> CreateTeamsByEveryTwo(List<IPlayer> players, string sport)
        {
            List<IPlayer> playerscopy = new List<IPlayer>(players);
            switch (sport)
            {
                case "Football":
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
                default:
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
            }

            List<IPlayer> listTeamA = new List<IPlayer>();
            List<IPlayer> listTeamB = new List<IPlayer>();

            listTeamA.Add(playerscopy[0]);
            listTeamB.Add(playerscopy[playerscopy.Count - 1]);
            playerscopy.RemoveAt(0);
            playerscopy.RemoveAt(playerscopy.Count - 1);

            int counter = 0;
            int targetCount = 2;
            bool addTOListB = true;
            foreach (IPlayer p in playerscopy)
            {
                if (counter == targetCount)
                {
                    if (addTOListB)
                    {
                        addTOListB = false;
                    }
                    else
                    {
                        addTOListB = true;
                    }
                    targetCount += 2;
                }

                if (addTOListB)
                {
                    listTeamB.Add(p);
                }
                else
                {
                    listTeamA.Add(p);
                }

                counter++;

            }

            Team teamA = new Team(listTeamA);
            Team teamB = new Team(listTeamB);

            return new List<Team>() { teamA, teamB };
        }
    }
}
