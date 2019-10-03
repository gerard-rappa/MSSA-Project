using System.Collections.Generic;
using System.Linq;

namespace TacoBoutIt.Models
{
    public class EFMemeRepository : IMemeRepository
    {
        private ApplicationDbContext context;

        public EFMemeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Meme> Memes => context.Memes;

        public void Add(Meme meme)
        {
            context.Memes.Add(meme);
            context.SaveChanges();
        }
    }
}
