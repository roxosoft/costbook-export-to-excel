using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class LaborerConfiguration : IEntityTypeConfiguration<Laborer>
    {
        public void Configure(EntityTypeBuilder<Laborer> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.ToTable("Laborer");
        }
    }
}