using EF010.IntitialMigration.Entities;

namespace EF010.CodeFirstMigration.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int? OfficeId { get; set; }
        public Office? Office { get; set; }

        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}