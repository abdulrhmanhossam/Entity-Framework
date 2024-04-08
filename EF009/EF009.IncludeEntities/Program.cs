using EF009.IncludeEntities.Data;
using EF009.IncludeEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF009.IncludeEntities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();

            //var itemsInOrderOne01 = context.OrderDetails.Where(o => o.OrderId == 1);

            var orderDetails01 = context.Orders.
                Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == 1)!.OrderDetails;
            Console.WriteLine($"Items Count in Order01 is {orderDetails01.Count()}");

            var audit = new AuditEntry()
            {
                UserName = "Abdulrhman",
                Action = "Read Order Count"
            };

            //context.Set<AuditEntry>().Add(audit);
            //context.SaveChanges();

            foreach (var item in context.OrderWithDetailsViews)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
