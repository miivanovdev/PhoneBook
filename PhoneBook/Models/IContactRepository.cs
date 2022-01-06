using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public interface IContactRepository
    {
        IQueryable<Contact> Contacts { get; }

        void AddContact(Contact newContact);

        void DeleteContact(Contact newContact);

        void UpdateContact(Contact newContact);

        void Save();
    }
}
