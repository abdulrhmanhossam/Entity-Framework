using EF009.BasicSetup.Data;

namespace EF009.BasicSetup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new AppDbContext())
            {
                foreach (var product in context.Products)
                {
                    Console.WriteLine(product.Name);
                }
            }
            Console.Read();
        }
    }
}
