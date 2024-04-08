using EF006.UsingContextFactory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF006.UsingContextFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json").Build();

            var connecationString = configuration.GetSection("constr").Value;

            var services = new ServiceCollection();
            services.AddDbContextFactory<AppDbContext>(options => options
            .UseSqlServer(connecationString));

            IServiceProvider servicesProvider = services.BuildServiceProvider();

            var contextFactory = servicesProvider.
                GetService<IDbContextFactory<AppDbContext>>();

            using (var context = contextFactory!.CreateDbContext())
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
