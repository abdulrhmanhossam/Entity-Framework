using EF006.UsingContextFactory.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF006.UsingContextFactory.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Wallet> wallets { get; set; }


    }
}

