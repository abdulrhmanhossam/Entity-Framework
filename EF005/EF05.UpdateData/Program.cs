namespace EF05.UpdateData
{
    internal class Program
    {
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                // Update Wallet (id = 2) increase Balance by 1000
                var wallet = context.wallets!.SingleOrDefault(x => x.Id == 2);
                wallet!.Balance += 1000;
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
