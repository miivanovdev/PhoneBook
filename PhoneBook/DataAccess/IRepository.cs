using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.DataAccess
{
    public interface IRepository<T>
    {
        IQueryable<T> GetItems { get; }

        Task AddItemAsync(T newContact);

        Task DeleteItemAsync(T newContact);

        Task UpdateItemAsync(T newContact);

        Task SaveAsync();
    }
}
