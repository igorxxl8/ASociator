using ASociator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASociator.Data.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        Task<User> GetUserById(int? userId);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByPasswordEmail(string password, string email);

        Task AddUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(User user);

        List<User> GetUsers();

        List<User> GetUsersByPartialName(string name);

        bool IsExists(int id);
    }
}
