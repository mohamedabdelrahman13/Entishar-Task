using Microsoft.EntityFrameworkCore;
using Users_CRUD.Models;

namespace Users_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedDate)
                .HasDefaultValueSql("SYSDATETIME()");
        }
        public DbSet<User> users { get; set; }
    }
}
