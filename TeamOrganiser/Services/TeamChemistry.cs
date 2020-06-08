using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public static float SetTeamChemistry(List<Player> team)
        {
            /*
            List<Player> TeamList = new List<Player>(team); 

            Dictionary<Player, String> bestPositions = new Dictionary<Player, string>();
            float score = 0;
            int i = 0;
            while (i < TeamList.Count) // queue.hasNext()
            {
                Player player = TeamList[i];
                List<String> playersBestPositions = player.GetTopPositions();
                for (int j = 0; j < playersBestPositions.Count; j++)
                {
                    String topPosition = playersBestPositions.get(j);
                    if (!bestPositions.containsValue(topPosition))
                    {
                        bestPositions.put(player, topPosition);
                        queue.remove();
                        score += player.getAPositionRating((topPosition));
                        break;
                    }
                    else
                    {
                        Player originalPlayer = MapUtils.getKey(bestPositions, topPosition);
                        int originalRating = originalPlayer.getAPositionRating(topPosition);
                        int newPlayerRating = player.getAPositionRating(topPosition);
                        if (newPlayerRating > originalRating)
                        {
                            bestPositions.put(player, topPosition);
                            score += newPlayerRating - originalRating;
                            queue.add(originalPlayer);
                            break;
                        }
                    }
                    if (j == playersBestPositions.size() - 1)
                    {
                        bestPositions.put(player, "PositionNotFound");
                    }
                }
            }

            float maxScore = 0;
            foreach (Player player in team)
            {
                String bestPos = player.getBestPosition();
                maxScore += player.getAPositionRating(bestPos);
            }

            return (score / maxScore) * 100;
            */

            return 1.2F;
        }
    }
}
