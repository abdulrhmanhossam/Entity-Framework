using Microsoft.Extensions.Configuration;
using System;
namespace EF05.SetupEFCoreModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
                var configuration = new ConfigurationBuilder().
                    AddJsonFile("appsettings.json").Build();
            
            var connectionString = configuration.GetSection("constr").Value;
            Console.WriteLine(connectionString);

            Console.ReadKey();
        }
    }
}
