using EF006.ExternalConfiguration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF006.ExternalConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();

            var connecationString = configuration.GetSection("constr").Value;

            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(connecationString);

            var options = optionBuilder.Options;

            using (AppDbContext context = new AppDbContext(options))
            {
                foreach (var item in context.wallets)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }
    }
}
