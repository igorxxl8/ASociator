using ASociator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.ViewModels
{
    public class UsersListViewModel
    {
        public IEnumerable<UserProfileViewModel> Users { get; set; }
        public SelectList Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string Country { get; set; }
        public string City { get; set; }

        public int UsersTotal { get; set; }
    }
}
