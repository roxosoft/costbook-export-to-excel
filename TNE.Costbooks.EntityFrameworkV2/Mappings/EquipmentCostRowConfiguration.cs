using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class EquipmentCostRowConfiguration : IEntityTypeConfiguration<EquipmentCostRow>
    {
        public void Configure(EntityTypeBuilder<EquipmentCostRow> builder)
        {
            builder.HasBaseType<DataRow>();

            builder.Property(x => x.EquipmentId).HasColumnName("EquipmentId");

            builder.Property(x => x.DayPrice).HasColumnName("DayPrice");
            builder.Property(x => x.WeekPrice).HasColumnName("WeekPrice");
            builder.Property(x => x.MonthPrice).HasColumnName("MonthPrice");

            builder.HasOne(x => x.Equipment)
                .WithMany()
                .HasForeignKey(x => x.EquipmentId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Row");
        }
    }
}