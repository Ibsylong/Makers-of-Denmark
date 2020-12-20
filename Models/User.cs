using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makers_of_Denmark.Models
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string schoolName { get; set; }
        public Badge[] badges { get; set; }
        public Makerspace[] makerspaces { get; set; }
    }
}

