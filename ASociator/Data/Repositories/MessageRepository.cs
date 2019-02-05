using ASociator.Data.Interfaces;
using ASociator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly ApplicationContext _context;
        private DbSet<Message> DbSet;

        public MessageRepository(ApplicationContext context)
        {
            _context = context;
            DbSet = _context.Set<Message>();
        }

        public void SendMessage(Message message)
        {
            DbSet.Add(message);
            _context.SaveChanges();
        }
    }
}
