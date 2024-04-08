using EF006.DbContextLifeTime.Data;
using EF006.DbContextLifeTime.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EF006.DbContextLifeTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json").Build();

            var connecationString = configuration.GetSection("constr").Value;

            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(connecationString)
                .LogTo(Console.WriteLine, LogLevel.Information);

            var options = optionBuilder.Options;

            using (AppDbContext context = new AppDbContext(options))
            {
                var wallet01 = new Wallet
                {

                    Holder = "Jasem",
                    Balance = 10000
                };
                context.Wallets.Add(wallet01);

                var wallet02 = new Wallet
                {
                    
                    Holder = "Rema",
                    Balance = 2000m
                };
                context.Wallets.Add(wallet02);



                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
