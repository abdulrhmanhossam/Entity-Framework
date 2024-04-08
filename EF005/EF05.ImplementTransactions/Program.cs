namespace EF05.ImplementTransactions
{
    internal class Program
    {
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    // transfer $500 from wallet id 3 to wallet id 2
                    var fromWallet = context.wallets!.Single(x => x.Id == 3);
                    var toWallet = context.wallets!.Single(x => x.Id == 2);

                    var amountToTransfer = 500;

                    // operation #1 withdraw 500 from wallet id 3
                    fromWallet.Balance -= amountToTransfer;
                    context.SaveChanges();
                    
                    // operation #2 Add 500 to wallet id 2
                    toWallet.Balance += amountToTransfer;
                    context.SaveChanges();

                    transaction.Commit();
                }
            }
                Console.ReadKey();
        }
    }
}
