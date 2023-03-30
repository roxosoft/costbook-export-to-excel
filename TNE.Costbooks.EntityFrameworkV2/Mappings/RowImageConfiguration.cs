using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class RowImageConfiguration: EntityConfiguration<RowImage>
    {
        public override void Configure(EntityTypeBuilder<RowImage> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.Row)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.RowId);

            builder.Property(x => x.Number).HasColumnName("Number");
            builder.Property(x => x.Caption).HasColumnName("Caption");
            builder.Property(x => x.Path).HasColumnName("Path");

            builder.ToTable("RowImage");
        }
    }
}