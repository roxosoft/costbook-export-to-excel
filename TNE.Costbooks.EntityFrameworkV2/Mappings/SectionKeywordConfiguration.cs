using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class SectionKeywordConfiguration : EntityConfiguration<SectionKeyword>
    {
        public override void Configure(EntityTypeBuilder<SectionKeyword> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.SectionId).HasColumnName("SectionId");
            builder.Property(x => x.Text).HasColumnName("Text");

            builder
                .HasOne(x => x.Section)
                .WithMany(x => x.Keywords)
                .HasForeignKey(x => x.SectionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("SectionKeyword");
        }
    }
}