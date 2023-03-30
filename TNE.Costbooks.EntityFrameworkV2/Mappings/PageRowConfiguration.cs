using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class PageRowConfiguration : IEntityTypeConfiguration<PageRow>
    {
        public void Configure(EntityTypeBuilder<PageRow> builder)
        {
            builder.HasBaseType<Row>();

            builder.Property(x => x.Title).HasColumnName("PageRow_Title");

            builder.ToTable("Row");
        }
    }
}