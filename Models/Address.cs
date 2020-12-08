using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makers_of_Denmark.Models
{
    public class Address
    {
        public string  street { get; set; }
        public string postCode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
