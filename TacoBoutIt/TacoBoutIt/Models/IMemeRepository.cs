using System.Linq;

namespace TacoBoutIt.Models
{
    public interface IMemeRepository
    {
        IQueryable<Meme> Memes { get; }
        IQueryable<Meme> LocalMemes(Location userLocation);
        void Add(Meme meme);
    }
}
