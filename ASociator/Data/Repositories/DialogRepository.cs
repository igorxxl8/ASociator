using ASociator.Data.Interfaces;
using ASociator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Repositories
{
    public class DialogRepository : IDialogRepository
    {
        private readonly ApplicationContext _context;
        private DbSet<Dialog> DbSet;

        public DialogRepository(ApplicationContext context)
        {
            _context = context;
            DbSet = _context.Set<Dialog>();
        }

        public void CreateDialog(Dialog dialog)
        {
            DbSet.Add(dialog);
            _context.SaveChanges();
        }

        public Dialog GetDialogBetweenUsersIfExists(int userId1, int userId2)
        {
            return DbSet.Where(d => (d.AddresseeID == userId1 && d.InitiatorID == userId2) ||
                                            (d.AddresseeID == userId2 && d.InitiatorID == userId1)
                                    ).SingleOrDefault();
        }

        public Dialog GetDialogWithMessages(int dialogID)
        {
            var item = DbSet.Find(dialogID);
            _context.Entry(item).Collection(d => d.Messages).Load();
            _context.Entry(item).Reference(d => d.Addressee).Load(); //TODO: is this really needed???
            _context.Entry(item).Reference(d => d.Initiator).Load();
            return item;
        }

        public List<Dialog> GetUserDialogs(int userID)
        {
            return DbSet.Where(d => d.AddresseeID == userID || d.InitiatorID == userID)
                    .Include(d => d.Initiator)
                    .Include(d => d.Addressee)
                    .ToList();
        }

        public void RemoveDialog(int id)
        {
            var item = DbSet.Find(id);
            if (item != null)
            {
                DbSet.Remove(item);
            }
            _context.SaveChanges();
        }
    }
}
