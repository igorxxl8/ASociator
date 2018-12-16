using ASociator.Data.Interfaces;
using ASociator.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Users => _context.Users.Include(u => u.Role);
        

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public Task<User> GetUserByEmail(string email) => _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> GetUserByPasswordEmail(string password, string email) => await _context.Users
                                                                                                .Include(u => u.Role)
                                                                                                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);


        public Task<User> GetUserById(int? userId) => _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        public async Task UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public bool IsExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
