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


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasData(
        //        new Product
        //        {
        //            Id=1,
        //            Title="test",
        //            Description="test",
        //            Price=10,
        //            Color="red",
        //            Img= "https://urlis.net/5adb09cf", // img_url
        //            CategoryId= 1,
        //        },
        //        new Category
        //        {
        //            Id = 1,
        //            Name = "test1",
        //        },
        //        new Category
        //        {
        //            Id = 2,
        //            Name = "test2",
        //            ParentId = 1,
        //        },
        //        new Field
        //        {
        //            Id = 1,
        //            Filde = "test",
        //            CategoryId = 2,
        //        },
        //        new FildeValue
        //        {
        //            Id = 1,
        //            Value = "test",
        //            FildeId = 1,
        //            ProductId = 1,
        //        }
        //        );
        //}
    }
}
