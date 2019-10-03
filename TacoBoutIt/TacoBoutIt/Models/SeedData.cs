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
                        Latitude = 71.0000,
                        Longitude = 25.0000,
                        ImgUrl = "imgPath"
                    },
                    new Meme
                    {
                        Latitude = 71.0000,
                        Longitude = 25.0000,
                        ImgUrl = "imgPath2"
                    },
                    new Meme
                    {
                        Latitude = 71.0000,
                        Longitude = 25.0000,
                        ImgUrl = "imgPath3"
                    } 
               );
                context.SaveChanges();
            }
        }        
    }    
}
