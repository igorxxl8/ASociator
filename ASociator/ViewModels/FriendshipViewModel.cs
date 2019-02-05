using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.ViewModels
{
    public class FriendshipViewModel
    {
        public int ID { get; set; }

        public int FriendId { get; set; }

        public UsersListItemViewModel Friend { get; set; }

        public int MeID { get; set; }
    }
}
