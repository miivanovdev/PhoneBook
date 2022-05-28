using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PhoneBookDb.Models;

namespace PhoneBook.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо ввести имя!")]
        [Display(Name="Имя")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо ввести фамилию!")]
        [Display(Name="Фамилия")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(50)]
        public string SecondName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }        

        public IFormFile LoadImage { get; set; }

        public string SavedImage { get; set; }

        public ContactViewModel() { }

        public ContactViewModel(Contact contact)
        {
            Id = contact.Id;
            Name = contact.Name;
            Surname = contact.Surname;
            SecondName = contact.SecondName;
            PhoneNumber = contact.PhoneNumber;
            Address = contact.Address;
            Description = contact.Description;
            SavedImage = contact.Image;
        }
                
        public Contact ToContact()
        {
            return new Contact()
            {
                Name = this.Name,
                Surname = this.Surname,
                SecondName = this.SecondName,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                Description = this.Description,
                Image = this.SavedImage
            };
        }
        
    }
}
