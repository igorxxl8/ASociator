using ASociator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Data.Interfaces
{
    public interface IMessageRepository
    {
        void SendMessage(Message message);

    }
}
