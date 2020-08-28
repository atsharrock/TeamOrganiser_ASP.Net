using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeamOrganiser.Models.Players
{
    public class PlayerSports
    {
        [Key] public int Id { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        [ForeignKey("Sport")]
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
