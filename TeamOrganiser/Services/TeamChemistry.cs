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
        public static int SetFootballChemistry(List<FootballPlayer> team)
        {
            List<FootballPlayer> teamCopy = new List<FootballPlayer>(team);
            Dictionary<FootballPlayer, String> bestPositions = new Dictionary<FootballPlayer, string>();
            float score = 0f;

            int i = 0;
            while (i < teamCopy.Count) // queue.hasNext()
            {
                FootballPlayer player = teamCopy[i];
                List<String> playersBestPositions = player.GetTopPositions();
                for (int j = 0; j < playersBestPositions.Count; j++)
                {
                    String topPosition = playersBestPositions[j];
                    if (!bestPositions.ContainsValue(topPosition))
                    {
                        bestPositions.Add(player, topPosition);
                        teamCopy.RemoveAt(i);
                        score += player.GetPositionRating(topPosition);
                        break;
                    }
                    else
                    {
                        FootballPlayer originalPlayer = bestPositions.FirstOrDefault(p => p.Value.Equals(topPosition)).Key;
                        int originalRating = originalPlayer.GetPositionRating(topPosition);
                        int newPlayerRating = player.GetPositionRating(topPosition);
                        if (newPlayerRating > originalRating)
                        {
                            if (bestPositions.ContainsKey(player))
                            {
                                bestPositions[player] = topPosition;
                            }
                            else
                            {
                                bestPositions.Add(player, topPosition);
                            }
                            score += newPlayerRating - originalRating;
                            teamCopy.Add(originalPlayer);
                            teamCopy.Remove(player);
                            bestPositions.Remove(originalPlayer);
                            break;
                        }
                    }
                    if (j == playersBestPositions.Count() - 1)
                    {
                        bestPositions.Add(player, "PositionNotFound");
                        teamCopy.Remove(player);
                    }
                }
            }

            float maxScore = 0f;
            foreach (FootballPlayer player in team)
            {
                String bestPos = player.GetTopPositions()[0];
                maxScore += player.GetPositionRating(bestPos);
            }

            var result = ((score / maxScore) * 100);
            return (int)result;
        }
    }
}
