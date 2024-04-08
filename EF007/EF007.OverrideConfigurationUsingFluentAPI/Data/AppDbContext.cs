using EF007.OverrideConfigurationUsingFluentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF007.OverrideConfigurationUsingFluentAPI.Data
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

            modelBuilder.Entity<User>().ToTable("tblUsers");
            modelBuilder.Entity<Comment>().ToTable("tblComments");
            modelBuilder.Entity<Tweet>().ToTable("tblTweets");
            modelBuilder.Entity<Comment>().Property(p => p.Id)
                .HasColumnName("CommentId");
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
