using System;
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
        //As of right now, home page just takes the 250 most recent memes.
        //Maybe add pagination?
        public IQueryable<Meme> Memes => context.Memes.Take(250);
        public IQueryable<Meme> LocalMemes(Location userLocation)
        {

            const double radiusEarthMiles = 3958.762079;
            var distRatio = userLocation.Range / radiusEarthMiles;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            //convert Lat to radians
            double startLatRad = userLocation.Latitude * Math.PI / 180;
            //convert Lon to radians
            double startLonRad = userLocation.Longitude * Math.PI / 180;

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(0)));
            var endLonRads = startLonRad
                + Math.Atan2(
                    Math.Sin(((Math.PI) / 2)) * distRatioSine * startLatCos,
                    distRatioCosine - startLatSin * Math.Sin(endLatRads));
            //convert lat back to double
            double endLatDeg = endLatRads * 180 / Math.PI;
            //convert lon back to double
            double endLonDeg = endLonRads * 180 / Math.PI;

            double latRange = Math.Abs(userLocation.Latitude - endLatDeg);
            double lonRange = Math.Abs(userLocation.Longitude - endLonDeg);


            return context.Memes.Where(x => x.Longitude <= userLocation.Longitude + lonRange &&
                                            x.Longitude >= userLocation.Longitude - lonRange &&
                                            x.Latitude <= userLocation.Latitude + latRange &&
                                            x.Latitude >= userLocation.Latitude - latRange);
        }
        public void Add(Meme meme)
        {
            if (meme.Latitude == 0 && meme.Longitude == 0)
            {
                meme.Latitude = 25.0;
                meme.Longitude = -71.0;
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
