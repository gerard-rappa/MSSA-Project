using System.Linq;

namespace TacoBoutIt.Models
{
    public interface IMemeRepository
    {
        IQueryable<Meme> Memes { get; }
        void Add(Meme meme);
    }
}
