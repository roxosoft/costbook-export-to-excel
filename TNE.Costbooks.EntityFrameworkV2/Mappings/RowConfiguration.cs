using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class RowConfiguration : EntityConfiguration<Row>
    {
        public override void Configure(EntityTypeBuilder<Row> builder)
        {
            base.Configure(builder);

            builder.Ignore(x => x.Type);

            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.Index).HasColumnName("Index");
            builder.Property(x => x.Level).HasColumnName("Level");
            builder.Property(x => x.FileName).HasColumnName("FileName");
            builder.Property(x => x.Copiable).HasColumnName("Copiable");

            builder
                .HasDiscriminator<int>("Discriminator")
                .HasValue<UnknownRow>((int)RowType.Unknown)
                .HasValue<SectionRow>((int)RowType.Section)
                .HasValue<EquipmentCostRow>((int)RowType.EquipmentCost)
                .HasValue<MaterialCostRow>((int)RowType.MaterialCost)
                .HasValue<AggregateCostRow>((int)RowType.AggregateCost)
                .HasValue<AggregateCostRowMLET>((int)RowType.AggregateCostMLET)
                .HasValue<PurchaseCostRow>((int)RowType.PurchaseCost)
                .HasValue<TextRow>((int)RowType.Text)
                .HasValue<CustomCostRow>((int)RowType.CustomCost)
                .HasValue<PageRow>((int)RowType.Page);

            builder
                .HasOne(x => x.Book)
                .WithMany(x => x.Rows)
                .HasForeignKey(x => x.BookId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Images)
                .WithOne(x => x.Row)
                .HasForeignKey(x => x.RowId);

            builder.ToTable("Row");
        }
    }
}