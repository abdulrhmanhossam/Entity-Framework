using EF006.DependancyInjection.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF006.DependancyInjection.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Wallet> wallets { get; set; }


    }
}

