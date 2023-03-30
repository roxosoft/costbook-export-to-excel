using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class AggregateCostRowConfiguration : IEntityTypeConfiguration<AggregateCostRow>
    {
        public void Configure(EntityTypeBuilder<AggregateCostRow> builder)
        {
            builder.HasBaseType<DataRow>();

            builder
                .HasOne(x => x.Aggregate)
                .WithMany()
                .HasForeignKey(x => x.AggregateId);
            builder
                .Property(x => x.AggregateId)
                .HasColumnName("AggregateCostRow_AggregateId");

            builder
                .HasOne(x => x.Crew)
                .WithMany()
                .HasForeignKey(x => x.CrewId);

            builder
                .HasOne(x => x.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(x => x.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(x => x.UnitOfMeasureId)
                .HasColumnName("UnitOfMeasureId");

            builder
                .Property(x => x.Hours)
                .HasColumnName("Hours");

            builder
                .Property(x => x.MaterialPrice)
                .HasColumnName("MaterialPrice");

            builder.Property(x => x.LaborPrice)
                .HasColumnName("LaborPrice");
            builder.Property(x => x.SellPrice)
                .HasColumnName("SellPrice");
            builder.Property(x => x.TotalPrice)
                .HasColumnName("TotalPrice");

            builder.Property(x => x.Name)
                .HasColumnName("CostRow_Name");


            builder.ToTable("Row");
        }
    }
}