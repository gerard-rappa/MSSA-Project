using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TacoBoutIt.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Memes.Any())
            {
                context.Memes.AddRange(                    
                    new Meme
                    {
                        Latitude = 27.132481,
                        Longitude = -73.086548,
                        ImgUrl = "default1.jpg"
                    },
                    new Meme
                    {
                        Latitude = 27.132481,
                        Longitude = -73.086548,
                        ImgUrl = "default2.jpg"
                    },
                    new Meme
                    {
                        Latitude = 32.911587,
                        Longitude = -117.151517,
                        ImgUrl = "default3.png"
                    } 
               );
                context.SaveChanges();
            }
        }        
    }    
}
