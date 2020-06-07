using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
