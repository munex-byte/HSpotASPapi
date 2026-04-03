using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and fashion items" },
                new Category { Id = 3, Name = "Home & Garden", Description = "Home improvement and gardening supplies" },
                new Category { Id = 4, Name = "Sports", Description = "Sports equipment and accessories" },
                new Category { Id = 5, Name = "Books", Description = "Books and educational materials" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Wireless Headphones", Description = "High-quality wireless headphones", Price = 99.99m, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest smartphone model", Price = 699.99m, CategoryId = 1 },
                new Product { Id = 3, Name = "Laptop", Description = "Powerful laptop for work and gaming", Price = 1299.99m, CategoryId = 1 },
                new Product { Id = 4, Name = "T-Shirt", Description = "Comfortable cotton t-shirt", Price = 19.99m, CategoryId = 2 },
                new Product { Id = 5, Name = "Jeans", Description = "Classic denim jeans", Price = 49.99m, CategoryId = 2 },
                new Product { Id = 6, Name = "Sneakers", Description = "Running sneakers", Price = 79.99m, CategoryId = 2 },
                new Product { Id = 7, Name = "Hammer", Description = "Heavy-duty hammer", Price = 14.99m, CategoryId = 3 },
                new Product { Id = 8, Name = "Garden Hose", Description = "Flexible garden hose", Price = 29.99m, CategoryId = 3 },
                new Product { Id = 9, Name = "Lawn Mower", Description = "Electric lawn mower", Price = 199.99m, CategoryId = 3 },
                new Product { Id = 10, Name = "Basketball", Description = "Official size basketball", Price = 24.99m, CategoryId = 4 },
                new Product { Id = 11, Name = "Tennis Racket", Description = "Professional tennis racket", Price = 89.99m, CategoryId = 4 },
                new Product { Id = 12, Name = "Yoga Mat", Description = "Non-slip yoga mat", Price = 34.99m, CategoryId = 4 },
                new Product { Id = 13, Name = "Programming Book", Description = "Learn C# programming", Price = 39.99m, CategoryId = 5 },
                new Product { Id = 14, Name = "Cookbook", Description = "Delicious recipes collection", Price = 24.99m, CategoryId = 5 },
                new Product { Id = 15, Name = "History Book", Description = "World history overview", Price = 29.99m, CategoryId = 5 },
                new Product { Id = 16, Name = "Bluetooth Speaker", Description = "Portable Bluetooth speaker", Price = 49.99m, CategoryId = 1 },
                new Product { Id = 17, Name = "Tablet", Description = "10-inch tablet", Price = 299.99m, CategoryId = 1 },
                new Product { Id = 18, Name = "Mouse", Description = "Wireless computer mouse", Price = 19.99m, CategoryId = 1 },
                new Product { Id = 19, Name = "Jacket", Description = "Waterproof jacket", Price = 69.99m, CategoryId = 2 },
                new Product { Id = 20, Name = "Hat", Description = "Baseball cap", Price = 14.99m, CategoryId = 2 },
                new Product { Id = 21, Name = "Socks", Description = "Cotton socks pack", Price = 9.99m, CategoryId = 2 },
                new Product { Id = 22, Name = "Drill", Description = "Cordless power drill", Price = 79.99m, CategoryId = 3 },
                new Product { Id = 23, Name = "Paint Brush", Description = "Professional paint brush", Price = 7.99m, CategoryId = 3 },
                new Product { Id = 24, Name = "Flower Pot", Description = "Ceramic flower pot", Price = 12.99m, CategoryId = 3 },
                new Product { Id = 25, Name = "Soccer Ball", Description = "Official soccer ball", Price = 19.99m, CategoryId = 4 },
                new Product { Id = 26, Name = "Dumbbells", Description = "Set of dumbbells", Price = 49.99m, CategoryId = 4 },
                new Product { Id = 27, Name = "Swimming Goggles", Description = "Anti-fog swimming goggles", Price = 14.99m, CategoryId = 4 },
                new Product { Id = 28, Name = "Science Fiction Book", Description = "Bestselling sci-fi novel", Price = 16.99m, CategoryId = 5 },
                new Product { Id = 29, Name = "Biography", Description = "Inspiring biography", Price = 21.99m, CategoryId = 5 },
                new Product { Id = 30, Name = "Children's Book", Description = "Fun children's story", Price = 11.99m, CategoryId = 5 },
                new Product { Id = 31, Name = "Keyboard", Description = "Mechanical keyboard", Price = 119.99m, CategoryId = 1 },
                new Product { Id = 32, Name = "Monitor", Description = "27-inch monitor", Price = 249.99m, CategoryId = 1 },
                new Product { Id = 33, Name = "Webcam", Description = "HD webcam", Price = 39.99m, CategoryId = 1 }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}