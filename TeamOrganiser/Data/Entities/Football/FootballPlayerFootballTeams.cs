using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TeamOrganiser.Models;
using TeamOrganiser.Models.Football;

namespace TeamOrganiser.Data.Entities.Football
{
    public class FootballPlayerFootballTeams
    {
        [Key]
        public int If { get; set; }

        [ForeignKey("FootballPlayer")]
        public int FootballPlayerId { get; set; }
        public FootballPlayer FootballPlayer { get; set; }

        [ForeignKey("FootballTeam")]
        public int FootballTeamId { get; set; }
        public FootballTeam FootballTeam { get; set; }
    }
}
