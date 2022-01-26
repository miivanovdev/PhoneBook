using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Models;
using PhoneBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactRepository _Repository;
        private readonly ILogger<HomeController> _logger;

        public int PageSize = 4;

        public HomeController(IContactRepository repository, ILogger<HomeController> logger)
        {
            _Repository = repository;
            _logger = logger;
        }

        public ViewResult Index(int contactPage = 1)
        {
            var pageInfo = new PagingInfo()
            {
                CurrentPage = contactPage,
                ItemsPerPage = PageSize,
                TotalItems = _Repository.Contacts.Count()
            };

            var contact = _Repository.Contacts
                            .OrderBy(x => x.Id)
                            .Skip((contactPage - 1) * PageSize)
                            .Take(PageSize);

            return View(new ContactListViewModel()
            {
                Contacts = contact,
                PagingInfo = pageInfo
            });
        }


        public ViewResult ContactCardForm(int id)
        {
            var contact = _Repository.Contacts.FirstOrDefault(x => x.Id == id);

            contact.Image = @"wwwroot/Images/img_avatar.png";

            return View(contact);
        }

        [HttpGet]
        public ViewResult AddContactForm()
        {
            return View("AddContactForm", new Contact());
        }
                
        [HttpPost]
        public IActionResult AddContactForm(Contact newContact)
        {
            if(newContact != null)            
                _Repository.AddContact(newContact);            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult EditContactForm(int id)
        {
            var contact = _Repository.Contacts.FirstOrDefault(x => x.Id == id);           

            return View("AddContactForm", contact);            
        }

        [HttpPost]
        public IActionResult EditContactForm(Contact editedContact)
        {
            var contactToUpdate = _Repository.Contacts.FirstOrDefault(x => x.Id == editedContact.Id);

            if(contactToUpdate != null)
            {
                contactToUpdate.Name = editedContact.Name;
                contactToUpdate.PhoneNumber = editedContact.PhoneNumber;
                contactToUpdate.SecondName = editedContact.SecondName;
                contactToUpdate.Surname = editedContact.Surname;
                contactToUpdate.Description = editedContact.Description;
                contactToUpdate.Address = editedContact.Address;

                _Repository.Save();
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteContact(int id)
        {
            var contactToDelete = _Repository.Contacts.First(x => x.Id == id);

            if(contactToDelete != null)
                _Repository.DeleteContact(contactToDelete);

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
