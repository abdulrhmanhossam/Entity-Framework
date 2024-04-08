using EF006.DependancyInjection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF006.DependancyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();

            var connecationString = configuration.GetSection("constr").Value;

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options
            .UseSqlServer(connecationString));

            IServiceProvider servicesProvider = services.BuildServiceProvider();

            using(var context = servicesProvider.GetRequiredService<AppDbContext>())
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
