using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EF006.UsingContextPooling.Data;

namespace EF006.UsingContextPooling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json").Build();

            var connecationString = configuration.GetSection("constr").Value;

            var services = new ServiceCollection();
            services.AddDbContextPool<AppDbContext>(options => options
            .UseSqlServer(connecationString));

            IServiceProvider servicesProvider = services.BuildServiceProvider();

            using (var context = servicesProvider.GetRequiredService<AppDbContext>())
            {
                foreach (var item in context.Wallets)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }
    }
}
