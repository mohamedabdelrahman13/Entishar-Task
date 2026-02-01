using Microsoft.EntityFrameworkCore;
using Users_CRUD.Models;

namespace Users_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
    }
}
