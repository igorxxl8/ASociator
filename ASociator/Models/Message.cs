using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Models
{
    public class Message
    {
        public int ID { get; set; }

        public int AuthorID { get; set; }

        public User Author { get; set; }

        public int DialogID { get; set; }

        public Dialog Dialog { get; set; }

        public DateTime DateSent { get; set; }

        public string Content { get; set; }
    }
}
