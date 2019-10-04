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
            if(meme.Latitude == 0 && meme. Longitude == 0)
            {
                meme.Latitude = 71;
                meme.Longitude = 25;
            }
            context.Memes.Add(meme);
            context.SaveChanges();
        }
    }
}
