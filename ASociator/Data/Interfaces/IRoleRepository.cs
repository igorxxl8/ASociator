using ASociator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<UserRole> Roles { get; }

        Task<UserRole> GetRole(string role);
    }
}
