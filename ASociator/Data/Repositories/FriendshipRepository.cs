using ASociator.Data.Interfaces;
using ASociator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly ApplicationContext _context;
        private DbSet<Friendship> DbSet;

        public FriendshipRepository(ApplicationContext context)
        {
            _context = context;
            DbSet = _context.Set<Friendship>();
        }


        public IEnumerable<Friendship> Users => throw new NotImplementedException();

        public void Create(int userId1, int userId2)
        {
            var friendship = new Friendship
            {
                MeID = userId1,
                FriendID = userId2
            };

            DbSet.Add(friendship);
            _context.SaveChanges();
        }

        public Friendship GetFriendshipIfExists(int userId1, int userId2)
        {
            return DbSet.Where(f => (f.FriendID == userId1 && f.MeID == userId2) ||
                                    (f.MeID == userId1 && f.FriendID == userId2))
                                    .SingleOrDefault();
        }

        public List<Friendship> GetUserFriends(int userId)
        {
            return DbSet.Where(f => f.FriendID == userId || f.MeID == userId)
                .Include(f => f.Friend)
                .Include(f => f.Me)
                .ToList();
        }

        public void Remove(int id)
        {
            var item = DbSet.Find(id);
            if (item != null)
            {
                DbSet.Remove(item);
            }

            _context.SaveChanges();
        }

        public bool RemoveFriendshipIfExists(int userId1, int userId2)
        {
            var friendship = GetFriendshipIfExists(userId1, userId2);
            if (friendship is null)
            {
                return false;
            }
            Remove(friendship.ID);
            return true;
        }
    }
}
