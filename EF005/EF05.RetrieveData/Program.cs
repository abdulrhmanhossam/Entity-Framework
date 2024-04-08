using System;

namespace EF05.RetrieveData
{
    internal class Program
    {
        public static void Main()
        {
            using(var context = new AppDbContext())
            {
                foreach (var wallet in context.wallets!)
                {
                    Console.WriteLine(wallet);
                }
            }

            Console.ReadKey();
        }
    }
}
