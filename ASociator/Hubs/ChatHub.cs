using ASociator.Data.Interfaces;
using ASociator.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Hubs
{
    public class ChatHub : Hub
    {
        IMessageRepository _messageRepository;

        public ChatHub(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task SendMessage(int dialogId, int senderId, string message)
        {
            var newMessage = new Message();
            newMessage.DateSent = DateTime.Now;
            newMessage.AuthorID = senderId;
            newMessage.DialogID = dialogId;
            newMessage.Content = message;
            newMessage.ID = 0;
            _messageRepository.SendMessage(newMessage);

            await Clients.All.SendAsync("ReceiveMessage", dialogId, senderId, message);
        }
    }
}
