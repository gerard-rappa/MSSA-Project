using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using TacoBoutIt.Models;

namespace TacoBoutIt.Controllers
{
    public class MemeController: Controller
    {
        private IMemeRepository repository;

        public MemeController(IMemeRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Memes.OrderByDescending(x=> x));

        public ViewResult LocalList(Location userLocation) => View(repository.LocalMemes(userLocation).OrderByDescending(x=> x));

        public ViewResult Add()=>  View();

        [HttpPost]
        public IActionResult Add(double Latitude, double Longitude)
        {
            Meme meme = new Meme();
            meme.Latitude = Latitude;
            meme.Longitude = Longitude;
            var files = HttpContext.Request.Form.Files;
            string path = "wwwroot/Images/";
            string extension = "";
            if (files.Count == 0)
            {
                return RedirectToAction("List");
            }            
            ///////////////////////////////////////////////////////////////////////
            // Gets extension from uploaded file and adds it to unique image path
            // Only accepts jpg, png, gif, and webm as of right now
            ///////////////////////////////////////////////////////////////////////
            for (int i = files[0].FileName.Length - 1; i > 0; i--)
            {
                extension = files[0].FileName[i].ToString() + extension;
                if (files[0].FileName[i] == '.')
                {
                    break;
                }
            }
            //checks for acceptable extensions
            extension = extension.ToLower();
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".webm")
            {
                meme.ImgUrl = Guid.NewGuid().ToString() + extension;
                path += meme.ImgUrl;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                repository.Add(meme);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult LocalList(double Latitude, double Longitude)
        {            
            Location userLocation = new Location();
            userLocation.Latitude = Latitude;
            userLocation.Longitude = Longitude;
            if (userLocation.Latitude == 0 && userLocation.Longitude == 0)
            {
                userLocation.Longitude = -73.086548;
                userLocation.Latitude = 27.132481;
            }
            return RedirectToAction("LocalList", userLocation);
        }
    }
}
