using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamOrganiser.Models.Account
{
    public class UserAccount
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Account Type")]
        [Required(ErrorMessage = "Please Select a type")]
        public AccountType AccountType { get; set; }

        [Required(ErrorMessage = "Please Enter an Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Password must be larger than 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
