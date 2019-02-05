using ASociator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Interfaces
{
    public interface IFriendshipRepository
    {
        IEnumerable<Friendship> Users { get; }

        Friendship GetFriendshipIfExists(int userId1, int userId2);

        List<Friendship> GetUserFriends(int userId);

        void Create(int userId1, int userId2);

        void Remove(int id);

        bool RemoveFriendshipIfExists(int userId1, int userId2);
    }
}
