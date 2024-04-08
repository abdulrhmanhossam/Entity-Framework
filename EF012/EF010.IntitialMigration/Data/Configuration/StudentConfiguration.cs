using EF012.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF012.CodeFirstMigration.Data.Configuration
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
        }
    }
}
