using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class TextRowConfiguration : IEntityTypeConfiguration<TextRow>
    {
        public void Configure(EntityTypeBuilder<TextRow> builder)
        {
            builder.HasBaseType<DataRow>();

            builder.Property(x => x.Text).HasColumnName("TextRow_Text");
            builder.Property(x => x.Subtype).HasColumnName("TextRow_Subtype");
            builder.Property(x => x.Options).HasColumnName("TextRow_Options");

            builder.ToTable("Row");
        }
    }
}