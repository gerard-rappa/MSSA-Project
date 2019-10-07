using Microsoft.EntityFrameworkCore;

namespace TacoBoutIt.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Meme> Memes { get; set; }
    }
}
