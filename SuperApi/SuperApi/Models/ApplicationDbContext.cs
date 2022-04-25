using Microsoft.EntityFrameworkCore;

namespace SuperApi.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
