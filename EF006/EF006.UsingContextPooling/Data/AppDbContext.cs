using EF006.UsingContextPooling.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF006.UsingContextPooling.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Wallet> Wallets { get; set; }


    }
}

