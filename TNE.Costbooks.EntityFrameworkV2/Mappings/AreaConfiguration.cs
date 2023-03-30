using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {   
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.PostalCode).HasColumnName("PostalCode");
            builder.HasIndex(x => x.PostalCode).IsUnique();
            
            builder.ToTable("Area");
        }
    }
}