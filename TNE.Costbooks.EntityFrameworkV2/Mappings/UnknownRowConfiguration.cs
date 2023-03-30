using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class UnknownRowConfiguration : IEntityTypeConfiguration<UnknownRow>
    {
        public void Configure(EntityTypeBuilder<UnknownRow> builder)
        {
            builder.HasBaseType<Row>();

            builder.Property(x => x.Text).HasColumnName("UnknownRow_Text");
            builder.ToTable("Row");
        }
    }
}