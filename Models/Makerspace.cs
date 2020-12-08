using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makers_of_Denmark.Models
{
    public class Makerspace
    {
        public string id { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public ContactInformation contactInformation { get; set; }
        public string vatNumber { get; set; }
        public string logoUrl { get; set; }
        public string accessType { get; set; }
        public string organization { get; set; }
        public Array tools { get; set; }
    }
}
