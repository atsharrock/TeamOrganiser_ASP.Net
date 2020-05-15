using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TeamOrganiser.Models.Players
{
    public class Player : IPlayer
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Football")]
        public bool Football { get; set; }

        [Display(Name = "Hockey")]
        public bool Hockey { get; set; }

        [Display(Name = "Basketball")]
        public bool Basketball { get; set; }

        public int Rating { get; set; }

        public Player(string firstName, string lastName, string email, string contactNumber, 
                        bool football, bool hockey, bool basketball)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
            Football = football;
            Hockey = hockey;
            Basketball = basketball;
        }

        public Player() 
        { 
        
        }
    }
}
