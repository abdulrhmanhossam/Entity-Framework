using EF007.ConfigurationByConvention.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF007.ConfigurationByConvention.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var connecationString = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connecationString);
        }
    }
}
