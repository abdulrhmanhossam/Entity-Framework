namespace EF012.CodeFirstMigration.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string? SectionName { get; set; }
        public TimeSlot TimeSlot { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;
        public int? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
