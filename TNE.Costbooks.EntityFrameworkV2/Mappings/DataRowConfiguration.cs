using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class DataRowConfiguration : IEntityTypeConfiguration<DataRow>
    {
        public void Configure(EntityTypeBuilder<DataRow> builder)
        {
            builder.HasBaseType<Row>();

            builder.Property(x => x.SectionId).HasColumnName("DataRow_SectionId");

            builder
                .HasOne(x => x.Section)
                .WithMany(x => x.Data)
                .HasForeignKey(x => x.SectionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.HeaderId)
                .HasColumnName("HeaderId");
            builder
                .HasOne(x => x.Header)
                .WithMany()
                .HasForeignKey(x => x.HeaderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Title).HasColumnName("DatatRow_Title");

            builder.ToTable("Row");
        }
    }
}