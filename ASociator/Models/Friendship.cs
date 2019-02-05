using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Models
{
    public class Friendship
    {
        public int ID { get; set; }

        public int MeID { get; set; }

        public User Me { get; set; }

        public int FriendID { get; set; }

        public User Friend { get; set; }
    }
}
