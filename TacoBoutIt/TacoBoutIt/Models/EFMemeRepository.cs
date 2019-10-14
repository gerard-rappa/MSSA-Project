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
        //As of right now, home page just takes the 30 most recent memes.
        //Maybe add pagination?
        public IQueryable<Meme> Memes => context.Memes.Take(250);
        public IQueryable<Meme> LocalMemes(Location userLocation) => context.Memes.Where(x => x.Longitude <= userLocation.Longitude + 1 &&
                                                                                             x.Longitude >= userLocation.Longitude - 1 &&
                                                                                             x.Latitude <= userLocation.Latitude + 1 &&
                                                                                             x.Latitude >= userLocation.Latitude - 1);

        public void Add(Meme meme)
        {
            if (meme.Latitude == 0 && meme.Longitude == 0)
            {
                meme.Latitude = 27.132481;
                meme.Longitude = -73.086548;
            }
            context.Memes.Add(meme);
            context.SaveChanges();
        }

        public Meme DeleteMeme(string memeUrl)
        {
            Meme dbEntry = context.Memes.FirstOrDefault(p => p.ImgUrl.Equals(memeUrl));
            if (dbEntry != null)
            {
                context.Memes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
