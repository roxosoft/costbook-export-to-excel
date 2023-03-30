using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class CustomCostRowConfiguration : IEntityTypeConfiguration<CustomCostRow>
    {
        public void Configure(EntityTypeBuilder<CustomCostRow> builder)
        {
            builder.HasBaseType<DataRow>();

            builder
                .Property(x => x.UnitOfMeasureId)
                .HasColumnName("UnitOfMeasureId");
            builder
                .HasOne(x => x.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(x => x.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Name).HasColumnName("CustomCostRow_Name");
            builder.Property(x => x.Costs).HasColumnName("CustomCostRow_Costs");

            builder.ToTable("Row");
        }
    }
}