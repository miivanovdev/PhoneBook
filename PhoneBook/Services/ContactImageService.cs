using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PhoneBook.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class ContactImageService
    {
        private readonly IWebHostEnvironment _HostEnvironment;

        private readonly string _DefaultImage = @"default_avatar.png";

        public ContactImageService(IWebHostEnvironment hostEnvironment)
        {
            _HostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
        }

        public async Task UploadImage(ContactViewModel contactView)
        {
            if (contactView.LoadImage != null)
            {
                DeleteImage(contactView.SavedImage);

                contactView.SavedImage = await UploadFile(contactView.LoadImage);
            }
            else
            {
                contactView.SavedImage = _DefaultImage;
            }
        }

        private async Task<string> UploadFile(IFormFile formFile)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            var filePath = Path.Combine(_HostEnvironment.WebRootPath, "Avatars", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileSteam);
            }

            return fileName;
        }

        public void DeleteImage(string image)
        {
            if (!String.IsNullOrEmpty(image) &&
                !String.Equals(image, _DefaultImage, StringComparison.InvariantCultureIgnoreCase) &&
                System.IO.File.Exists(Path.Combine(_HostEnvironment.WebRootPath, "Avatars", image)))
            {
                System.IO.File.Delete(Path.Combine(_HostEnvironment.WebRootPath, "Avatars", image));
            }
        }
    }
}
