using EF006.ParameterlessConstractor.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF006.ParameterlessConstractor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public virtual DbSet<Wallet> wallets { get; set; }

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
