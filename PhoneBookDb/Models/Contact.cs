using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookDb.Models
{
    public class Contact : EntityBase
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string PhoneNumber { get; set; }
    
        public string Address { get; set; }    

        public string Description { get; set; }

        public string Image { get; set; }
    }
}
