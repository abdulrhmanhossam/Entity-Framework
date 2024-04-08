using EF010.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.IntitialMigration
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FirstName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired(); // not null

            builder.Property(x => x.LastName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Office)
                .WithOne(x => x.Instructor)
                .HasForeignKey<Instructor>(x => x.OfficeId)
                .IsRequired(false);

            builder.HasIndex(x => x.OfficeId).IsUnique();

            builder.ToTable("Instructors");

            builder.HasData(LoadInstructors());
        }

        private List<Instructor> LoadInstructors()
        {
            return new List<Instructor>
            {
                new Instructor{ Id = 1, FirstName = "Ahmed", LastName = "Abdullah", OfficeId = 1},
                new Instructor{ Id = 2, FirstName = "Yasmeen", LastName = "Mohammed", OfficeId = 2},
                new Instructor{ Id = 3, FirstName = "Khalid", LastName = "Hassan", OfficeId = 3 },
                new Instructor{ Id = 4, FirstName = "Nadia", LastName = "Ali", OfficeId = 4 },
                new Instructor{ Id = 5, FirstName = "Omar", LastName = "Ibrahim", OfficeId = 5 },
            };
        }
    }
}