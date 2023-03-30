using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder
                .Property(x => x.Name)
                .HasColumnName("Name");

            builder
                .Property(x => x.ParentId)
                .HasColumnName("ParentId");

            builder.ToTable("Equipment");
        }
    }
}