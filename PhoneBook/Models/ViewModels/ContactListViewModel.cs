using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models.ViewModels
{
    public class ContactListViewModel
    {        
        public IEnumerable<Contact> Contacts { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
