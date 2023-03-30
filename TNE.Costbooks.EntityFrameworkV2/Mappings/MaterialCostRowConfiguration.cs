using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class MaterialCostRowConfiguration : IEntityTypeConfiguration<MaterialCostRow>
    {
        public void Configure(EntityTypeBuilder<MaterialCostRow> builder)
        {
            builder.HasBaseType<DataRow>();

            builder
                .Property(x => x.MaterialId)
                .HasColumnName("MaterialId");
            builder
                .HasOne(x => x.Material)
                .WithMany()
                .HasForeignKey(x => x.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.UnitOfMeasureId)
                .HasColumnName("UnitOfMeasureId");
            builder
                .HasOne(x => x.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(x => x.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.MaterialPrices)
                .HasColumnName("MaterialPrices");

            builder.ToTable("Row");
        }
    }
}