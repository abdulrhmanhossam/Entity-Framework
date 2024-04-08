
namespace EF05.InsertData
{
    internal class Program
    {
        static void Main()
        {
            var wallet = new Wallet
            {
                Holder = "Hossam",
                Balance = 13000,
            };

            using (var context = new AppDbContext())
            {
                context.wallets!.Add(wallet);
                context.SaveChanges();
            }

                Console.ReadKey();
        }
    }
}
