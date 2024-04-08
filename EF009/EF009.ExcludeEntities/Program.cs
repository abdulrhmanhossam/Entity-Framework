using EF009.ExcludeEntities.Data;

namespace EF009.ExcludeEntities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var product in context.Products)
                {
                    Console.WriteLine($"{product.Name} ....... Loaded at " +
                        $"{product.Snapshot}");
                }
            }
            Console.ReadKey();
        }
    }
}
