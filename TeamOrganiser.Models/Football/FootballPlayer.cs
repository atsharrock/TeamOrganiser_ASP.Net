using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Models.Players;
using TeamOrganiser.Models.Teams;

namespace TeamOrganiser.Models
{
    public class FootballPlayer : IFootballPlayer
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int Rating { get; set; }

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

        public void SetRating()
        {
            List<int> DefenceRatings = new List<int>() { CentreBack, Sweeper, FullBack, WingBack };
            List<int> MidfieldRatings = new List<int>() { CentreMidfield, DefensiveMidfield, AttackingMidfield, WideMidfield };
            List<int> AttackRatings = new List<int>() { Forward, CentreForward, Winger };

            this.Defence = GetAverageOfPositionRating(DefenceRatings);
            this.Midfield = GetAverageOfPositionRating(MidfieldRatings);
            this.Attack = GetAverageOfPositionRating(AttackRatings);

            this.Rating = (Defence + Midfield + Attack) / 3;
        }

        private int GetAverageOfPositionRating(List<int> PositionRatings)
        {
            int count = 0;
            int rating = 0;

            foreach (int position in PositionRatings)
            {
                if (position != 0)
                {
                    count++;
                    rating += position;
                }
            }

            if (count == 0)
            {
                return 0;
            }

            return rating / count;
        }

        public int GetPositionRating(string position)
        {
            return (int)this.GetType().GetProperty(position).GetValue(this);
        }

        public List<string> GetTopPositions()
        {
            Dictionary<string, int> PositionRatings = new Dictionary<string, int>()
            {
                { "CentreBack", CentreBack },
                { "Sweeper", Sweeper },
                { "FullBack", FullBack },
                { "WingBack", WingBack },
                { "CentreMidfield", CentreMidfield },
                { "DefensiveMidfield", DefensiveMidfield },
                { "AttackingMidfield", AttackingMidfield },
                { "WideMidfield", WideMidfield },
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
