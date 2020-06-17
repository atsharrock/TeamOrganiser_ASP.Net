using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Teams;

namespace TeamOrganiser.Models
{
    public class FootballPlayer : Player, IFootballPlayer
    {
        [Key]
        public new int Id { get; set; }

        public int Defence { get; set; }
        public int CentreBack { get; set; }
        public int Sweeper { get; set; }
        public int FullBack { get; set; }
        public int WingBack { get; set; }
        public int Midfield { get; set; }
        public int CentreMidfield { get; set; }
        public int DefensiveMidfield { get; set; }
        public int AttackingMidfield { get; set; }
        public int WideMidfield { get; set; }
        public int Attack { get; set; }
        public int Forward { get; set; }
        public int CentreForward { get; set; }
        public int Winger { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public int SetRating()
        {
            int rating = 0;
            var TopPositions = GetTopPositions();
            foreach (var position in TopPositions)
            {
                rating += GetPositionRating(position);
            }

            return rating/3;
        }

        public int GetPositionRating(string position)
        {
            return (int)this.GetType().GetProperty(position).GetValue(this);
        }

        public List<string> GetTopPositions()
        {
            Dictionary<string, int> PositionRatings = new Dictionary<string, int>()
            {
                { "Defence", Defence },
                { "CentreBack", CentreBack },
                { "Sweeper", Sweeper },
                { "FullBack", FullBack },
                { "WingBack", WingBack },
                { "Midfield", Midfield },
                { "CentreMidfield", CentreMidfield },
                { "DefensiveMidfield", DefensiveMidfield },
                { "AttackingMidfield", AttackingMidfield },
                { "WideMidfield", WideMidfield },
                { "Attack", Attack },
                { "Forward", Forward },
                { "CentreForward", CentreForward },
                { "Winger", Winger }
            };

            var myList = PositionRatings.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            myList.Reverse();

            var TopThree = myList.Take(3).ToDictionary(d => d.Key, d => d.Value).Keys.ToList();

            return TopThree;
        }
    }
}
