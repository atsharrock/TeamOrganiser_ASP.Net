using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TeamOrganiser.Models.Player
{
    public class Player
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public IList<string> AssociatedSports { get; set; }

        public Player(string firstName, string lastName, string email, string contactNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
            IList<string> AssociatedSports = new List<string>();
        }
    }
}
