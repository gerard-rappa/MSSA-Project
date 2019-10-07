using Microsoft.AspNetCore.Mvc;
using TacoBoutIt.Models;
using System.Linq;

namespace TacoBoutIt.Controllers
{
    public class AdminController : Controller
    {
        private IMemeRepository repository;
        public AdminController(IMemeRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Memes.OrderByDescending(x=>x));
   
        [HttpPost]
        public IActionResult Delete(string memeUrl)
        {
            Meme deletedMeme = repository.DeleteMeme(memeUrl);
            if(deletedMeme != null)
            {
                TempData["message"] = $"{deletedMeme.ImgUrl} was deleted";
            }

            return RedirectToAction("Index");
        }
    }
}