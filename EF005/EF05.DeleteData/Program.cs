namespace EF05.DeleteData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var idToDelete = 4;
            using (var context = new AppDbContext())
            {
                var wallet = context.wallets!.Single(x => x.Id == idToDelete);
                context.wallets!.Remove(wallet);
                context.SaveChanges();
            }
                Console.ReadKey();
        }
    }
}
