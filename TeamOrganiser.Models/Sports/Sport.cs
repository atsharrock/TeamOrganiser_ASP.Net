using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeamOrganiser.Models.Players;

namespace TeamOrganiser.Models
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
