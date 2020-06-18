using System.ComponentModel.DataAnnotations;

namespace TeamOrganiser.Models.Players
{
    public class Player : IPlayer
    {
        [Key]
        [Required]
        public int Id { get; set; }

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

    }
}
