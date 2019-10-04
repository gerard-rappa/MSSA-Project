using Microsoft.AspNetCore.Mvc;
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

        public ViewResult LocalList(Location userLocation) => View(repository.LocalMemes(userLocation));

        public ViewResult Add()=>  View();

        [HttpPost]
        public IActionResult Add(Meme meme)
        {
            if (meme.ImgUrl == null)
            {
                return RedirectToAction("List");
            }
            repository.Add(meme);
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
                userLocation.Longitude = 73.086548;
                userLocation.Latitude = 27.132481;
            }
            return RedirectToAction("LocalList", userLocation);
        }
    }
}
