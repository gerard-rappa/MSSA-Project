using System.Collections.Generic;
using System.Linq;

namespace TacoBoutIt.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public EFReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Review> Reviews => context.Reviews;

        public void Add(Review review)
        {
            review.ImgUrl = "1";
            review.Location = "1";
            review.Username = "a@a.com";
            context.Reviews.Add(review);
            context.SaveChanges();
        }
    }
}
