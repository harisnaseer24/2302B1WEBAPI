using _2302B1CodeFirstAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace _2302B1CodeFirstAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

    }
}
