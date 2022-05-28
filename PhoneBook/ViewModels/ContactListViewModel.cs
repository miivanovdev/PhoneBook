using PhoneBookDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.ViewModels
{
    public class ContactListViewModel
    {        
        public List<Contact> Contacts { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
