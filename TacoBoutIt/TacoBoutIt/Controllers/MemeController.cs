using Microsoft.AspNetCore.Mvc;
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

        public ViewResult List() => View(repository.Memes);
        
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
    }
}
