using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class SectionDescriptionConfiguration : IEntityTypeConfiguration<SectionDescription>
    {
        public void Configure(EntityTypeBuilder<SectionDescription> builder)
        {
            builder.Property(x => x.SectionId).HasColumnName("SectionId");
            builder.Property(x => x.Text).HasColumnName("Text");

            builder
                .HasOne(x => x.Section)
                .WithMany(x => x.Descriptions)
                .HasForeignKey(x => x.SectionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("SectionDescription");
        }
    }
}