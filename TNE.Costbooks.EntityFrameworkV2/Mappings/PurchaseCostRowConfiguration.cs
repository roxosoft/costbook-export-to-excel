using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class PurchaseCostRowConfiguration : IEntityTypeConfiguration<PurchaseCostRow>
    {
        public void Configure(EntityTypeBuilder<PurchaseCostRow> builder)
        {
            builder.HasBaseType<DataRow>();

            builder
                .HasOne(x => x.Equipment)
                .WithMany()
                .HasForeignKey(x => x.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(x => x.EquipmentId)
                .HasColumnName("EquipmentId");

            builder
                .Property(x => x.PurchasePrice)
                .HasColumnName("PurchaseCostRow_PurchasePrice");
            builder
                .Property(x => x.DayPrice)
                .HasColumnName("DayPrice");
            builder
                .Property(x => x.WeekPrice)
                .HasColumnName("WeekPrice");

            builder.ToTable("Row");
        }
    }
}