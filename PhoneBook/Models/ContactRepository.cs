using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class ContactRepository : IContactRepository
    {
        private readonly PhoneBookContext _DbContext;

        public ContactRepository(PhoneBookContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IQueryable<Contact> Contacts => _DbContext.Contacts;

        public void AddContact(Contact newContact)
        {
            _DbContext.Contacts.Add(newContact);

            _DbContext.SaveChanges();
        }        

        public void DeleteContact(Contact removeContact)
        {
            _DbContext.Contacts.Remove(removeContact);

            _DbContext.SaveChanges();
        }

        public void UpdateContact(Contact updateContact)
        {
            //_DbContext.Contacts.Update(updateContact);

            _DbContext.Entry(updateContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _DbContext.SaveChanges();
        }

        public void Save()
        {
            _DbContext.SaveChanges();
        }
    }
}
