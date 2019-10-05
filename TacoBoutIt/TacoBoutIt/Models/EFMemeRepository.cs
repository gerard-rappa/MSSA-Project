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
        public IQueryable<Meme> LocalMemes(Location userLocation) => context.Memes.Where(x=> x.Longitude <= userLocation.Longitude + 1 &&
                                                                                             x.Longitude >= userLocation.Longitude - 1 &&
                                                                                             x.Latitude <= userLocation.Latitude +1 &&
                                                                                             x.Latitude >= userLocation.Latitude -1);

        public void Add(Meme meme)
        {
            if(meme.Latitude == 0 && meme. Longitude == 0)
            {
                meme.Latitude = 27.132481;
                meme.Longitude = -73.086548;
            }
            context.Memes.Add(meme);
            context.SaveChanges();
        }
    }
}
