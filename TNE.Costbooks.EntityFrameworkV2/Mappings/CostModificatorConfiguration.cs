using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class CostModificatorConfiguration : IEntityTypeConfiguration<CostModificator>
    {
        public void Configure(EntityTypeBuilder<CostModificator> builder)
        {
            builder.Property(x => x.AreaId).HasColumnName("AreaId");
            builder.Property(x => x.Equipment).HasColumnName("Equipment");
            builder.Property(x => x.Labor).HasColumnName("Labor");
            builder.Property(x => x.Material).HasColumnName("Material");
            builder.Property(x => x.AreaId).HasColumnName("AreaId");

            builder.HasOne(x => x.Area)
              .WithMany()
              .IsRequired()
              .HasForeignKey(x => x.AreaId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("CostModificator");
        }
    }
}