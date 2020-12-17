using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makers_of_Denmark.Models
{
    public class Event
    {
        public string id { get; set; }
        public string makerSpaceId { get; set; }
        public string address { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string description { get; set; }
        public User[] participants { get; set; }
        public string badge { get; set; }
    }
}
