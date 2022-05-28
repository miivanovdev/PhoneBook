using PhoneBookDb;
using PhoneBookDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.DataAccess
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly PhoneBookContext _DbContext;

        public ContactRepository(PhoneBookContext dbContext)
        {
            _DbContext = dbContext;
        }       

        public IQueryable<Contact> GetItems => _DbContext.Contacts;

        public async Task AddItemAsync(Contact newContact)
        {
            await _DbContext.Contacts.AddAsync(newContact);

            await _DbContext.SaveChangesAsync();
        }        

        public async Task DeleteItemAsync(Contact removeContact)
        {
            _DbContext.Contacts.Remove(removeContact);

            await _DbContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(Contact updateContact)
        {            
            _DbContext.Entry(updateContact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _DbContext.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _DbContext.SaveChangesAsync();
        }        
    }
}
