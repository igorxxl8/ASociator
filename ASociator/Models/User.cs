using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Sex { get; set; }

        public DateTime BirdthDay { get; set; }
 
        public string Country { get; set; }
        public string City { get; set; }

        public int? RoleId { get; set; }
        public UserRole Role { get; set; }
        
        public List<Friendship> Friends { get; set; }
        
        public List<Friendship> FriendOf { get; set; }

        public List<Dialog> UserDialogs { get; set; }

        public List<Dialog> DialogsToUser { get; set; }

        public List<Message> Messages { get; set; }

        public byte[] Avatar { get; set; }

        public User()
        {
            Friends = new List<Friendship>();
            FriendOf = new List<Friendship>();
        }
    }
}
