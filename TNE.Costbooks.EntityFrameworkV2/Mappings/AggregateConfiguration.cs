using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class AggregateConfiguration : IEntityTypeConfiguration<Aggregate>
    {
        public void Configure(EntityTypeBuilder<Aggregate> builder)
        {
            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();
            builder.ToTable("Aggregate");
        }
    }
}