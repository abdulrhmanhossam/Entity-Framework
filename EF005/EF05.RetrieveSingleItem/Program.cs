using EF05.RetrieveData;

namespace EF05.RetrieveSingleItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var itemIdToRetrieve = 2;
            using (var context = new AppDbContext())
            {
               var result = context.wallets!.
                    FirstOrDefault(x => x.Id == itemIdToRetrieve);

                Console.WriteLine(result);
            }
                Console.ReadKey();
        }
    }
}
