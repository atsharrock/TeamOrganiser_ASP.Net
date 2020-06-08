using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using TeamOrganiser.Models.Football;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Models
{
    public class FootballPlayer : Player, IFootballPlayer
    {
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
        

        public FootballPlayer(int id, string firstname, string lastname, string email, string contactnumber)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            ContactNumber = contactnumber;
        }

        public FootballPlayer()
        {

        }

        public int SetRating()
        {
            int rating = 0;
            var TopPositions = GetTopPositions();
            foreach (KeyValuePair<string, int> entry in TopPositions)
            {
                // do something with entry.Value or entry.Key
                rating += entry.Value;
            }

            return rating/3;
        }

        public Dictionary<string, int> GetTopPositions()
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

            var TopThree = myList.Take(3).ToDictionary(d => d.Key, d => d.Value);

            return TopThree;
        }
    }
}
