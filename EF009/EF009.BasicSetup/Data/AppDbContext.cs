using EF009.BasicSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF009.BasicSetup.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products", schema: "Inventory")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .ToTable("Orders", schema: "Sales")
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderDetails>()
                .ToTable("OrderDetails", schema: "Sales")
                .HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
