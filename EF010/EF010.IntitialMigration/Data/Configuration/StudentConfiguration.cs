using EF010.IntitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.IntitialMigration.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FirstName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.ToTable("Students");

            builder.HasData(LoadStudents());
        }

        private static List<Student> LoadStudents()
        {
            return new List<Student>
            {
                 new Student() { Id = 1, FirstName = "Fatima", LastName = "Ali" },
                 new Student() { Id = 2, FirstName = "Noor" , LastName = "Saleh" },
                 new Student() { Id = 3, FirstName = "Omar" , LastName = "Youssef" },
                 new Student() { Id = 4, FirstName = "Huda" , LastName = "Ahmed" },
                 new Student() { Id = 5, FirstName = "Amira" , LastName = "Tariq" },
                 new Student() { Id = 6, FirstName = "Zainab" , LastName = "Ismail" },
                 new Student() { Id = 7, FirstName = "Yousef" , LastName = "Farid" },
                 new Student() { Id = 8, FirstName = "Layla" , LastName = "Mustafa" },
                 new Student() { Id = 9, FirstName = "Mohammed" , LastName = "Adel" },
                 new Student() { Id = 10, FirstName = "Samira" , LastName = "Nabil" }
            };
        }
    }
}
