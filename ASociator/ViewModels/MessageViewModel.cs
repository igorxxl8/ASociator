using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.ViewModels
{
    public class MessageViewModel
    {
        public int ID { get; set; }

        public int AuthorID { get; set; }

        public string Author { get; set; }

        public DateTime DateSent { get; set; }

        public int DialogID { get; set; }

        public string Content { get; set; }
    }
}
