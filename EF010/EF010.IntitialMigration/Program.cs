using EF010.IntitialMigration.Data;
using Microsoft.EntityFrameworkCore;

namespace EF010.IntitialMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var item in context.Sections.Include(x => x.Course))
                {
                    Console.WriteLine($"Section: {item.SectionName}, " +
                        $"Course: {item.Course.CourseName}");
                }
            }
            Console.ReadKey();
        }
    }
}
