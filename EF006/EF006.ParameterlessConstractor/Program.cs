using EF006.ParameterlessConstractor.Data;

namespace EF006.ParameterlessConstractor
{
    internal class Program
    {
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                var allWallets = context.wallets.ToList();
                foreach (var wallet in allWallets)
                {
                    Console.WriteLine(wallet);
                }
            }

            Console.ReadKey();
        }
    }
}
