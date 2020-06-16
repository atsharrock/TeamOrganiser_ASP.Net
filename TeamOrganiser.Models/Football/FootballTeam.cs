using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeamOrganiser.Models.Teams;

namespace TeamOrganiser.Models.Football
{
    public class FootballTeam : Team
    {
        public List<FootballPlayer> PlayerList { get; set; }
    }
}
