using Microsoft.EntityFrameworkCore;
using WebMarke_App.Models;

namespace WebMarke_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FildeValue> Values { get; set; }
    }
}
