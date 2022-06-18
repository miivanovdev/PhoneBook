using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Services;
using PhoneBook.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactManagerService _ContactManagerService;                
        private readonly ILogger<HomeController> _logger;                

        public HomeController(ContactManagerService contactManagerService, ILogger<HomeController> logger)
        {

            _ContactManagerService = contactManagerService ?? throw new ArgumentNullException(nameof(contactManagerService));
            _logger = logger;
        }

        public async Task<ViewResult> Index(int contactPage = 1)
        {
            var viewModelList = await _ContactManagerService.GetContactListsAsync(contactPage);

            return View(viewModelList);
        }

        [HttpGet]
        public async Task<ViewResult> ContactCardForm(int id)
        {
            var contact = await _ContactManagerService.GetContactAsync(id);

            return View(contact);
        }

        [HttpGet]
        public ViewResult AddContactForm()
        {            
            return View("AddContactForm", new ContactViewModel());
        }
                
        [HttpPost]
        public async Task<IActionResult> AddContactForm(ContactViewModel newContactViewModel)
        {            
            if(ModelState.IsValid)
            {
                await _ContactManagerService.AddContact(newContactViewModel);

                return View("ContactCardForm", newContactViewModel);                
            }

            return View();
        }      

        [HttpGet]
        public async Task<ViewResult> EditContactForm(int id)
        {
            var contact = await _ContactManagerService.GetContactAsync(id);

            return View("AddContactForm", contact);            
        }

        [HttpPost]
        public async Task<IActionResult> EditContactForm(ContactViewModel editedContactViewModel)
        {
            await _ContactManagerService.UpdateContact(editedContactViewModel);

            return RedirectToAction("EditContactForm", new { id = editedContactViewModel.Id });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(ContactViewModel contact)
        {            
            await _ContactManagerService.DeleteContact(contact);
            
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
