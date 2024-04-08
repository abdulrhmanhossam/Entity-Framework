using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EF006.DbContextAndConcurrency.Data;
using EF006.DbContextAndConcurrency.Entities;

namespace EF006.DbContextAndConcurrency
{
    internal class Program
    {
        static AppDbContext? context;
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

            var connecationString = configuration.GetSection("constr").Value;

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options
            .UseSqlServer(connecationString));

            IServiceProvider servicesProvider = services.BuildServiceProvider();

            context = servicesProvider.GetRequiredService<AppDbContext>();

            var tasks = new[]
            {
                Task.Factory.StartNew(() => Jop01()),
                Task.Factory.StartNew(() => Jop02()),
            };

            Task.WhenAll(tasks).ContinueWith(t => { 
                Console.WriteLine("Job01 & Job02 Executed Concurrently!"); });

            Console.ReadKey();
        }

        static async Task Jop01()
        {
            var wallet01 = new Wallet { Holder = "Abdullah", Balance = 3000m };

            context!.Wallets.Add(wallet01);
            await context.SaveChangesAsync();
        }

        static async Task Jop02()
        {
            var wallet02 = new Wallet { Holder = "Hossam", Balance = 2700m };

            context!.Wallets.Add(wallet02);
            await context.SaveChangesAsync();
        }
    }
}


        


        
    
