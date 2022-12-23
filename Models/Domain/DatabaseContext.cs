using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AminesStream.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext (DbContextOptions<DatabaseContext>options) : base(options)
        {
            
        }

        public  DbSet<Genre>  Genre { set; get; }

        public DbSet<MovieGenre> MovieGenre { get; set; }

        public DbSet<Movie> Moive { get; set; }
    }
}
