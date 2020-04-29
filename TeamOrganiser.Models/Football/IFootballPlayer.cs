using System;
using System.Collections.Generic;
using System.Text;

namespace TeamOrganiser.Models.Football
{
    public interface IFootballPlayer
    {
        int Defence { get; set; }
        int CentreBack { get; set; }
        int Sweeper { get; set; }
        int FullBack { get; set; }
        int WingBack { get; set; }
        int Midfield { get; set; }
        int CentreMidfield { get; set; }
        int DefensiveMidfield { get; set; }
        int AttackingMidfield { get; set; }
        int WideMidfield { get; set; }
        int Attack { get; set; }
        int Forward { get; set; }
        int CentreForward { get; set; }
        int Winger { get; set; }
    }
}
