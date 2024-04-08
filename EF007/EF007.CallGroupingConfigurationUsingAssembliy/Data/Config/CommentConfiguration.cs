using EF007.CallGroupingConfigurationUsingAssembliy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF007.CallGroupingConfigurationUsingAssembliy.Data.Config
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("tblComments");
            builder.Property(p => p.Id).HasColumnName("CommentId");
        }
    }
}
