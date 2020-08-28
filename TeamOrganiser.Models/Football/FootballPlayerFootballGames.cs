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
    public class FootballPlayerFootballGames
    {
        [Key] public int Id { get; set; }

        [ForeignKey("FootballPlayer")]
        public int FootballPlayerId { get; set; }
        public FootballPlayer FootballPlayer { get; set; }

        [ForeignKey("FootballGame")]
        public int FootballGameId { get; set; }
        public FootballGame FootballGame { get; set; }
    }
}
