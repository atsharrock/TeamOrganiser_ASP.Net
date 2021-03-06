﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamOrganiser.Models.Football
{
    public class FootballGame
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<FootballPlayer> FootballPlayers { get; set; }
        public virtual ICollection<FootballTeam> FootballTeams { get; set; }

        public string Address { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public FootballTeam Winner { get; set; }
        public bool Status { get; set; } = true;

        public Guid IdentityUserId { get; set; }

        public FootballGame()
        {
            FootballPlayers = new List<FootballPlayer>();
            FootballTeams = new List<FootballTeam>();
        }
    }
}
