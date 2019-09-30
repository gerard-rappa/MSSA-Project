using System.Linq;

namespace TacoBoutIt.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        void Add(Review review);
    }
}
