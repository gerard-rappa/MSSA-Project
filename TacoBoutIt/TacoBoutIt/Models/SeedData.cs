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
            if (!context.Reviews.Any())
            {
                context.Reviews.AddRange(                    
                    new Review
                    {
                        Restaurant = "La Casa de La Gritona",
                        ReviewText = "Best tacos in the world",
                        Rating = 10,
                        Location = "Whatever google maps needs",
                        Username = "a@a.com",
                        ImgUrl = "imgPath"
                    },
                    new Review
                    {
                        Restaurant = "Taco Bell",
                        ReviewText = "...",
                        Rating = 1,
                        Location = "Whatever google maps needs",
                        Username = "a@a.com",
                        ImgUrl = "imgPath"
                    },
                    new Review
                    {
                        Restaurant = "Restaurant",
                        ReviewText = "ReviewGoesHere",
                        Rating = 0000,
                        Location = "Whatever google maps needs",
                        Username = "a@a.com",
                        ImgUrl = "imgPath"
                    } 
               );
                context.SaveChanges();
            }
        }        
    }    
}
