using ASociator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [Display(Name = "Sex")]
        public string Sex { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime BirdthDay { get; set; }
        
        [Display(Name = "Country")]
        public string Country { get; set; }
        
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Avatar")]
        public byte[] Avatar { get; set; }

        public ProfileViewModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Sex = user.Sex;
            BirdthDay = user.BirdthDay;
            Country = user.Country;
            City = user.City;
            Avatar = user.Avatar;
        }
    }
}
