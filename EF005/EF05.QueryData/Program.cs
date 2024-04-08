namespace EF05.QueryData
{
    internal class Program
    {
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                // retrieve all wallets with balance > 7000
                var walletsOver7000 = context.wallets!.Where(w => w.Balance > 7000);
                foreach (var wallet in walletsOver7000)
                {
                    Console.WriteLine(wallet);
                }
                
            }
                Console.ReadKey();
        }
    }
}
