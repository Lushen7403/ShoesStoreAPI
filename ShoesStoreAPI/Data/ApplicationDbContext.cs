using Microsoft.EntityFrameworkCore;
using ShoesStoreAPI.Models;

namespace ShoesStoreAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categoroies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand ()
                {
                    Id = 1,
                    BrandName = "Addidas"
                },
                new Brand()
                {
                    Id = 2,
                    BrandName = "Nike"
                },
                new Brand()
                {
                    Id = 3,
                    BrandName = "Gucci"
                },
                new Brand()
                {
                    Id = 4,
                    BrandName = "MLB"
                }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    CategoryName = "Giày thể thao"
                },
                new Category()
                {
                    Id = 2,
                    CategoryName = "Giày boot"
                },
                new Category()
                {
                    Id = 3,
                    CategoryName = "Giày cao gót"
                }
                );
            modelBuilder.Entity<Shoe>().HasData(
                new Shoe()
                {
                    Id = 1,
                    Name = "Giày thể thao nam Nike Air Force 1",
                    Price = 100,
                    Quantity = 1000,
                    BrandId = 2,
                    CategoryId = 1,
                    Description = "Giày đẹp, hiện đại, phù hợp vận động thể thao",
                    ImageUrl = "nikeair1.png"
                },
                new Shoe()
                {
                    Id = 2,
                    Name = "Giày thể thao nam Adidas Runfalcon",
                    Price = 79,
                    Quantity = 500,
                    BrandId = 1,
                    CategoryId = 1,
                    Description = "Giày thể thao nam kiểu dáng hiện đại, đi êm",
                    ImageUrl = "adidasrunfalcon.png"
                },
                new Shoe()
                {
                    Id = 3,
                    Name = "Giày Boot Nữ Gucci Black Rubber Horsebit",
                    Price = 150,
                    Quantity = 200,
                    BrandId = 3,
                    CategoryId = 2,
                    Description = "Giày boot nữ hiện dại, sang trọng, quý tộc",
                    ImageUrl = "gucciblackrubber.png"
                }
                );
            modelBuilder.Entity<Account>().HasData(
                new Account()
                {
                    Id = 1,
                    Name = "Nguyen Van Tu",
                    UserName = "Admin",
                    Password = "123456",
                    Address = "Binh Luc, Ha Nam",
                    Email = "tudepzai@gmail.com",
                    Role = "Admin"
                },
                new Account()
                {
                    Id = 2,
                    Name = "Ngo Van Binh",
                    UserName = "binhboong",
                    Password = "123456",
                    Address = "Chi Linh, Hai Duong",
                    Email = "binhboong@gmail.com",
                    Role = "Customer"
                }
                );
        }
    }
}
