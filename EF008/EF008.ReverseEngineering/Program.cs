using EF008.ReverseEngineering.Data;

namespace EF008.ReverseEngineering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var item in context.Speakers)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                }
            }
            Console.ReadKey();
        }
    }
}
