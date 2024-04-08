using EF006.DbContextAndConcurrency.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF006.DbContextAndConcurrency.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Wallet> Wallets { get; set; }


    }
}

