using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
                        Longitude = 73.086548,
                        ImgUrl = "imgPath"
                    },
                    new Meme
                    {
                        Latitude = 27.132481,
                        Longitude = 73.086548,
                        ImgUrl = "imgPath2"
                    },
                    new Meme
                    {
                        Latitude = 27.132481,
                        Longitude = 73.086548,
                        ImgUrl = "imgPath3"
                    } 
               );
                context.SaveChanges();
            }
        }        
    }    
}
