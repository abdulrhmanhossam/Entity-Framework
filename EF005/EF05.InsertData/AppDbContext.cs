
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace EF05.InsertData
{
    //  A DbContext instance represents a session with the database and can be used to
    //  query and save instances of your entities. DbContext is a combination of the
    //  Unit Of Work and Repository patterns.
    public class AppDbContext : DbContext
    {
        // Represent the collection of all entites
        public DbSet<Wallet>? wallets {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
