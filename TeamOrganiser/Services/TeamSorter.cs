using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Teams;

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
        /// Sorts two teams as fairly as possible based on multiple methods.
        /// All methods are compared to find the lowest score difference between each team.
        ///</summary>
        public static List<Team> CreateFairTeams(List<Player> listOfPlayers, string sport)
        {

            List<Team> alternating = CreateTeamsByAlternating(listOfPlayers, sport);
            List<Team> everyTwo = CreateTeamsByEveryTwo(listOfPlayers, sport);
            List<Team> pointSystem = CreateTeamsByPointSystem(listOfPlayers, sport);
            List<Team> buckets = CreateTeamsBySkillBuckets(listOfPlayers, sport);

            int alternatingTeamAScore = 0; int alternatingTeamBScore = 0;
            int everyTwoTeamAScore = 0; int everyTwoTeamBScore = 0;
            int pointSystemTeamAScore = 0; int pointSystemTeamBScore = 0;
            int bucketsTeamAScore = 0; int bucketsTeamBScore = 0;

            for (int i = 0; i < 2; i++) // two teams
            {
                if (i == 0)
                {
                    alternatingTeamAScore += alternating[i].TeamRating;
                    everyTwoTeamAScore += everyTwo[i].TeamRating;
                    pointSystemTeamAScore += pointSystem[i].TeamRating;
                    bucketsTeamAScore += buckets[i].TeamRating;
                }
                else
                {
                    alternatingTeamBScore += alternating[i].TeamRating;
                    everyTwoTeamBScore += everyTwo[i].TeamRating;
                    pointSystemTeamBScore += pointSystem[i].TeamRating;
                    bucketsTeamBScore += buckets[i].TeamRating;
                }
            }

            int alternatingScore = Math.Max(alternatingTeamAScore, alternatingTeamBScore) - Math.Min(alternatingTeamAScore, alternatingTeamBScore);
            int everyTwoScore = Math.Max(everyTwoTeamAScore, everyTwoTeamBScore) - Math.Min(everyTwoTeamAScore, everyTwoTeamBScore);
            int pointSystemScore = Math.Max(pointSystemTeamAScore, pointSystemTeamBScore) - Math.Min(pointSystemTeamAScore, pointSystemTeamBScore);
            int bucketsScore = Math.Max(bucketsTeamAScore, bucketsTeamBScore) - Math.Min(bucketsTeamAScore, bucketsTeamBScore);

            int winningScore = Math.Min(Math.Min(pointSystemScore, bucketsScore), Math.Min(alternatingScore, everyTwoScore));

            if (alternatingScore == winningScore)
            {
                Console.WriteLine("Alternating Won");
                return alternating;
            }
            else if (everyTwoScore == winningScore)
            {
                Console.WriteLine("everyTwoScore Won");
                return everyTwo;
            }
            else if (pointSystemScore == winningScore)
            {
                Console.WriteLine("pointSystemScore Won");
                return pointSystem;
            }
            else if (bucketsScore == winningScore)
            {
                Console.WriteLine("bucketsScore Won");
                return buckets;
            }

            // default return.
            return everyTwo;
        }


        ///<summary>
        /// Teams are assigned a player one after the other in order of rating.
        ///</summary>
        public static List<Team> CreateTeamsByAlternating(List<Player> players, string sport)
        {
            List<Player> playerscopy = new List<Player>(players);
            switch (sport)
            {
                case "Football":
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
                default:
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
            }

            List<Player> listTeamA = new List<Player>();
            List<Player> listTeamB = new List<Player>();

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
        public static List<Team> CreateTeamsByEveryTwo(List<Player> players, string sport)
        {
            List<Player> playerscopy = new List<Player>(players);
            switch (sport)
            {
                case "Football":
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
                default:
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
            }

            List<Player> listTeamA = new List<Player>();
            List<Player> listTeamB = new List<Player>();

            listTeamA.Add(playerscopy[0]);
            listTeamB.Add(playerscopy[playerscopy.Count - 1]);
            playerscopy.RemoveAt(0);
            playerscopy.RemoveAt(playerscopy.Count - 1);

            int counter = 0;
            int targetCount = 2;
            bool addTOListB = true;
            foreach (Player p in playerscopy)
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

        ///<summary>
        /// Teams are sorted by trying to make the team scores even after each player is assigned
        ///</summary>
        public static List<Team> CreateTeamsByPointSystem(List<Player> players, string sport)
        {
            List<Player> playerscopy = new List<Player>(players);
            switch (sport)
            {
                case "Football":
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
            }

            List<Player> teamAList = new List<Player>();
            List<Player> teamBList = new List<Player>();
            int teamAScore = 0;
            int teamBScore = 0;

            foreach (Player p in playerscopy)
            {
                int rating = p.Rating;
                if (teamAScore <= teamBScore && teamAList.Count < players.Count / 2)
                {
                    teamAScore += rating;
                    teamAList.Add(p);
                }
                else
                {
                    teamBScore += rating;
                    teamBList.Add(p);
                }
            }

            Team teamA = new Team(teamAList);
            Team teamB = new Team(teamBList);

            return new List<Team>() { teamA, teamB };
        }

        ///<summary>
        /// Teams are sorted by players being assigned a skill bucket.
        /// each team is then attempted to be given an equal amount of players
        /// in each skill bucket.
        ///</summary>
        public static List<Team> CreateTeamsBySkillBuckets(List<Player> players, string sport)
        {

            List<Player> playerscopy = new List<Player>(players);
            switch (sport)
            {
                case "Football":
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
            }

            List<Player> BucketOne = new List<Player>();
            List<Player> BucketTwo = new List<Player>();
            List<Player> BucketThree = new List<Player>();
            List<Player> BucketFour = new List<Player>();
            List<Player> BucketFive = new List<Player>();

            foreach (Player p in playerscopy)
            {
                int rating = p.Rating;
                if (rating <= 20)
                {
                    BucketOne.Add(p);
                }
                else if (rating > 20 && rating <= 40)
                {
                    BucketTwo.Add(p);
                }
                else if (rating > 40 && rating <= 60)
                {
                    BucketThree.Add(p);
                }
                else if (rating > 60 && rating <= 80)
                {
                    BucketFour.Add(p);
                }
                else if (rating > 80 && rating <= 100)
                {
                    BucketFive.Add(p);
                }
            }

            List<List<Player>> AllBuckets = new List<List<Player>>() { BucketOne, BucketTwo, BucketThree, BucketFour, BucketFive };

            List<Player> listTeamA = new List<Player>();
            List<Player> listTeamB = new List<Player>();

            int i = 0;
            foreach (List<Player> bucket in AllBuckets)
            {
                foreach (Player p in bucket)
                {
                    if (i % 2 == 0)
                    {
                        listTeamA.Add(p);
                    }
                    else
                    {
                        listTeamB.Add(p);
                    }
                    i++;
                }
            }

            Team teamA = new Team(listTeamA);
            Team teamB = new Team(listTeamB);

            return new List<Team>() { teamA, teamB };

        }
    }
}
