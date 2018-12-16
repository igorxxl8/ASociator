using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email not specified")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name not specified")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name not specified")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Birdthday not specified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{ÿyyy-MM-dd}")]
        public DateTime BirdthDay { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}
