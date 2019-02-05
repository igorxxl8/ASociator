using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Models
{
    public class Dialog
    {
        public int ID { get; set; }

        public string DialogName { get; set; }

        public int? InitiatorID { get; set; }

        public User Initiator { get; set; }

        public int? AddresseeID { get; set; }

        public User Addressee { get; set; }

        public List<Message> Messages { get; set; }
    }
}
