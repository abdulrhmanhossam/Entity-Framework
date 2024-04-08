using EF010.IntitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.IntitialMigration.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.CourseName).HasMaxLength(255);// nvarchar(255)
            builder.Property(x => x.CourseName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired(); // not null

            builder.Property(x => x.Price)
                .HasPrecision(15, 2);
            
            builder.ToTable("Courses");

            builder.HasData(LoadCourses());
        }

        private static List<Course> LoadCourses()
        {
            return new List<Course>
            {
                new Course { Id = 1, CourseName = "Mathematics", Price = 1000.00m },
                new Course { Id = 2, CourseName = "Physics", Price = 2000.00m},
                new Course { Id = 3, CourseName = "Chemistry", Price = 1500.00m },
                new Course { Id = 4, CourseName = "Biology", Price = 1200.00m },
                new Course { Id = 5, CourseName = "Computer Science", Price = 3000.00m }
            };
        }
    }
}