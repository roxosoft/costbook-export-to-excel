using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class SectionRowConfiguration : IEntityTypeConfiguration<SectionRow>
    {
        public void Configure(EntityTypeBuilder<SectionRow> builder)
        {
            builder.HasBaseType<Row>();

            builder.Property(x => x.ParentId).HasColumnName("SectionRow_ParentId");
            builder.Property(x => x.Number).HasColumnName("SectionRow_Number");
            builder.Property(x => x.Title).HasColumnName("SectionRow_Title");

            builder
                .HasOne(x => x.Parent)
                .WithMany(x => x.Subsections)
                .HasForeignKey(x => x.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Row");
        }
    }
}