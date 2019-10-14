using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TacoBoutIt.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "beavis";
        private const string adminPassword = "Password1!"
            ;
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            { 
                user = new IdentityUser("beavis");
                await userManager.CreateAsync(user, adminPassword); 
            }
        }
    }   
}
