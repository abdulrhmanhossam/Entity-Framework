namespace EF009.ExcludeEntities.Entities
{
    public class Product
    {
        public Product()
        {
            Snapshot = new Snapshot();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Description { get; set; }

        public Snapshot? Snapshot { get; set; }
    }
}
