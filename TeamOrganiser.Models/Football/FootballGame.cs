﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamOrganiser.Models.Teams;

namespace TeamOrganiser.Models.Football
{
    public class FootballGame
    {
        [Key]
        public int Id { get; set; }

        public List<FootballPlayer> Players { get; set; } = new List<FootballPlayer>();
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public string Address { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Team Winner { get; set; }

        public FootballGame()
        {

        }
    }
}
