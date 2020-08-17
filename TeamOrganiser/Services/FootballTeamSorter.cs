using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Teams;

namespace TeamOrganiser.Services
{
    ///<summary>
    /// The TeamSorter class sorts players into two groups
    /// of fair teams. Teams can be sorted randomly,
    /// based on their ratings or form.
    ///</summary>
    public static class FootballTeamSorter
    {

        ///<summary>
        /// Sorts two teams as fairly as possible based on multiple methods.
        /// All methods are compared to find the lowest score difference between each team.
        ///</summary>
        public static List<FootballTeam> CreateFairTeams(List<FootballPlayer> listOfPlayers)
        {

            List<FootballTeam> alternating = CreateTeamsByAlternating(listOfPlayers);
            List<FootballTeam> everyTwo = CreateTeamsByEveryTwo(listOfPlayers);
            List<FootballTeam> pointSystem = CreateTeamsByPointSystem(listOfPlayers);
            List<FootballTeam> buckets = CreateTeamsBySkillBuckets(listOfPlayers);

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
        public static List<FootballTeam> CreateTeamsByAlternating(List<FootballPlayer> players)
        {
            players = players.OrderBy(o => o.Rating).ToList();
            List<FootballPlayer> listTeamA = new List<FootballPlayer>();
            List<FootballPlayer> listTeamB = new List<FootballPlayer>();

            for (int i = 0; i < players.Count(); i++)
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

            FootballTeamService footballTeamService = new FootballTeamService();
            FootballTeam teamA = footballTeamService.CreateTeam(listTeamA).Result;
            FootballTeam teamB = footballTeamService.CreateTeam(listTeamB).Result;

            return new List<FootballTeam>() { teamA, teamB };
        }

        ///<summary>
        /// Teams are sorted by giving one team the best player. The next team
        /// get the next two best players and so on until there are no players left.
        ///</summary>
        public static List<FootballTeam> CreateTeamsByEveryTwo(List<FootballPlayer> players)
        {
            players = players.OrderBy(o => o.Rating).ToList();
            List<FootballPlayer> listTeamA = new List<FootballPlayer>();
            List<FootballPlayer> listTeamB = new List<FootballPlayer>();

            listTeamA.Add(players[0]);
            listTeamB.Add(players[players.Count - 1]);
            players.RemoveAt(0);
            players.RemoveAt(players.Count - 1);

            int counter = 0;
            int targetCount = 2;
            bool addTOListB = true;
            foreach (FootballPlayer p in players)
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

            FootballTeamService footballTeamService = new FootballTeamService();
            FootballTeam teamA = footballTeamService.CreateTeam(listTeamA).Result;
            FootballTeam teamB = footballTeamService.CreateTeam(listTeamB).Result;

            return new List<FootballTeam>() { teamA, teamB };
        }

        ///<summary>
        /// Teams are sorted by trying to make the team scores even after each player is assigned
        ///</summary>
        public static List<FootballTeam> CreateTeamsByPointSystem(List<FootballPlayer> players)
        {
            players = players.OrderBy(o => o.Rating).ToList();
            List<FootballPlayer> listTeamA = new List<FootballPlayer>();
            List<FootballPlayer> listTeamB = new List<FootballPlayer>();
            int teamAScore = 0;
            int teamBScore = 0;

            foreach (FootballPlayer p in players)
            {
                int rating = p.Rating;
                if (teamAScore <= teamBScore && listTeamA.Count < players.Count / 2)
                {
                    teamAScore += rating;
                    listTeamA.Add(p);
                }
                else
                {
                    teamBScore += rating;
                    listTeamB.Add(p);
                }
            }

            FootballTeamService footballTeamService = new FootballTeamService();
            FootballTeam teamA = footballTeamService.CreateTeam(listTeamA).Result;
            FootballTeam teamB = footballTeamService.CreateTeam(listTeamB).Result;

            return new List<FootballTeam>() { teamA, teamB };
        }

        ///<summary>
        /// Teams are sorted by players being assigned a skill bucket.
        /// each team is then attempted to be given an equal amount of players
        /// in each skill bucket.
        ///</summary>
        public static List<FootballTeam> CreateTeamsBySkillBuckets(List<FootballPlayer> players)
        {
            players = players.OrderBy(o => o.Rating).ToList();

            List<FootballPlayer> BucketOne = new List<FootballPlayer>();
            List<FootballPlayer> BucketTwo = new List<FootballPlayer>();
            List<FootballPlayer> BucketThree = new List<FootballPlayer>();
            List<FootballPlayer> BucketFour = new List<FootballPlayer>();
            List<FootballPlayer> BucketFive = new List<FootballPlayer>();

            foreach (FootballPlayer p in players)
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

            List<List<FootballPlayer>> AllBuckets = new List<List<FootballPlayer>>() { BucketOne, BucketTwo, BucketThree, BucketFour, BucketFive };

            List<FootballPlayer> listTeamA = new List<FootballPlayer>();
            List<FootballPlayer> listTeamB = new List<FootballPlayer>();

            int i = 0;
            foreach (List<FootballPlayer> bucket in AllBuckets)
            {
                foreach (FootballPlayer p in bucket)
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

            FootballTeamService footballTeamService = new FootballTeamService();
            FootballTeam teamA = footballTeamService.CreateTeam(listTeamA).Result;
            FootballTeam teamB = footballTeamService.CreateTeam(listTeamB).Result;

            return new List<FootballTeam>() { teamA, teamB };

        }
    }
}
