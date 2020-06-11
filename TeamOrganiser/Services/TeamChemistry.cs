using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Services
{
    public static class TeamChemistry
    {
        ///<summary>
        /// Sets the team chemistry based on the players top three positions.
        /// 100% chemistry is achieved by all players being in one of their
        /// top 3 positions with no duplicated positions.
        ///</summary>
        public static float SetTeamChemistry(List<Player> team, string sport)
        {
            float result = 0;
            List<Player> playerscopy = new List<Player>(team);
            switch (sport)
            {
                case "Football":
                    List<FootballPlayer> FootballTeam = playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    result = SetFootballChemistry(FootballTeam);
                    break;
                default:
                    playerscopy.Cast<FootballPlayer>().OrderBy(o => o.Rating).ToList();
                    break;
            }

            return result;
        }

        private static float SetFootballChemistry(List<FootballPlayer> team)
        {
            Dictionary<FootballPlayer, String> bestPositions = new Dictionary<FootballPlayer, string>();
            float score = 0;

            int i = 0;
            while (i < team.Count) // queue.hasNext()
            {
                FootballPlayer player = team[i];
                List<String> playersBestPositions = player.GetTopPositions();
                for (int j = 0; j < playersBestPositions.Count; j++)
                {
                    String topPosition = playersBestPositions[j];
                    if (!bestPositions.ContainsValue(topPosition))
                    {
                        bestPositions.Add(player, topPosition);
                        team.RemoveAt(i);
                        score += player.GetPositionRating((topPosition));
                        break;
                    }
                    else
                    {
                        FootballPlayer originalPlayer = bestPositions.FirstOrDefault(p => p.Value.Equals(topPosition)).Key;
                        int originalRating = originalPlayer.GetPositionRating(topPosition);
                        int newPlayerRating = player.GetPositionRating(topPosition);
                        if (newPlayerRating > originalRating)
                        {
                            bestPositions.Add(player, topPosition);
                            score += newPlayerRating - originalRating;
                            team.Add(originalPlayer);
                            break;
                        }
                    }
                    if (j == playersBestPositions.Count() - 1)
                    {
                        bestPositions.Add(player, "PositionNotFound");
                    }
                }
            }

            float maxScore = 0;
            foreach (FootballPlayer player in team)
            {
                String bestPos = player.GetTopPositions()[0];
                maxScore += player.GetPositionRating(bestPos);
            }

            return (score / maxScore) * 100;

            //return 1.2f;
        }
    }
}
