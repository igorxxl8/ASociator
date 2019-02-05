using ASociator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Interfaces
{
    public interface IDialogRepository
    {
        List<Dialog> GetUserDialogs(int userID);
        Dialog GetDialogWithMessages(int dialogID);
        Dialog GetDialogBetweenUsersIfExists(int userId1, int userId2);

        void CreateDialog(Dialog dialog);

        void RemoveDialog(int id);
    }
}
