using Microsoft.EntityFrameworkCore;
using PhoneBook.DataAccess;
using PhoneBook.ViewModels;
using PhoneBookDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class ContactManagerService
    {        
        private readonly IRepository<Contact> _Repository;

        private readonly ContactImageService _ContactImageService;

        private readonly int _PageSize = 4;

        public ContactManagerService(IRepository<Contact> repository, ContactImageService contactImageService)
        {
            _Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _ContactImageService = contactImageService ?? throw new ArgumentNullException(nameof(contactImageService));
        }

        public async Task<ContactListViewModel> GetContactListsAsync(int contactPage = 1)
        {
            var pageInfo = new PagingInfo()
            {
                CurrentPage = contactPage,
                ItemsPerPage = _PageSize,
                TotalItems = _Repository.GetItems.Count()
            };

            var contact = await _Repository.GetItems
                                .OrderBy(x => x.Id)
                                .Skip((contactPage - 1) * _PageSize)
                                .Take(_PageSize)
                                .ToListAsync();

            return new ContactListViewModel()
            {
                Contacts = contact,
                PagingInfo = pageInfo
            };
        }

        public async Task<ContactViewModel> GetContactAsync(int id)
        {
            var contact = await _Repository.GetItems.FirstOrDefaultAsync(x => x.Id == id);

            return new ContactViewModel(contact);
        }

        public async Task AddContact(ContactViewModel contactView)
        {
            await _ContactImageService.UploadImage(contactView);

            var newContact = contactView.ToContact();

            await _Repository.AddItemAsync(newContact);
        }

        public async Task DeleteContact(ContactViewModel contactToDelete)
        {
            var contact = await _Repository.GetItems.FirstOrDefaultAsync(x => x.Id == contactToDelete.Id);

            if (contact != null)
            {
                _ContactImageService.DeleteImage(contact.Image);

                await _Repository.DeleteItemAsync(contact);
            }
        }

        public async Task UpdateContact(ContactViewModel editContactViewModel)
        {
            var origContact = await _Repository.GetItems.FirstOrDefaultAsync(x => x.Id == editContactViewModel.Id);

            if (origContact != null)
            {
                await _ContactImageService.UploadImage(editContactViewModel);

                origContact.Name = editContactViewModel.Name;
                origContact.PhoneNumber = editContactViewModel.PhoneNumber;
                origContact.SecondName = editContactViewModel.SecondName;
                origContact.Surname = editContactViewModel.Surname;
                origContact.Description = editContactViewModel.Description;
                origContact.Address = editContactViewModel.Address;
                origContact.Image = editContactViewModel.SavedImage;

                await _Repository.UpdateItemAsync(origContact);
            }            
        }
    }
}
