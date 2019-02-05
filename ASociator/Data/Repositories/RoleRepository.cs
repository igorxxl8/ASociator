using ASociator.Data.Interfaces;
using ASociator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _context;

        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRole> Roles
        {
            get
            {
                return new List<UserRole>
                {
                    new UserRole { Id = 1, Name = "admin" },
                    new UserRole { Id = 2, Name = "user" }
            };
            }
        }


        public Task<UserRole> GetRole(string role) => _context.Roles.FirstOrDefaultAsync(u => u.Name == role);
    }
}
