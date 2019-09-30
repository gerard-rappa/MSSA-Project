using Microsoft.AspNetCore.Mvc;
using TacoBoutIt.Models;

namespace TacoBoutIt.Controllers
{
    public class ReviewController: Controller
    {
        private IReviewRepository repository;

        public ReviewController(IReviewRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Reviews);
        
        public ViewResult Add()=>  View();

        [HttpPost]
        public IActionResult Add(Review review)
        {
            if (review.Restaurant == null || review.ReviewText == null)
            {
                return RedirectToAction("List");
            }
            repository.Add(review);
            return RedirectToAction("List");
        }
    }
}
