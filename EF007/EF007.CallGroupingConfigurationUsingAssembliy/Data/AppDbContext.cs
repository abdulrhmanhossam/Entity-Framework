using EF007.CallGroupingConfigurationUsingAssembliy.Entities;
using EF007.CallGroupingConfigurationUsingAssembliy.Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF007.CallGroupingConfigurationUsingAssembliy.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Any Configuration at this assembly scope 
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }

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
