using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder
                .HasOne(x => x.Parent)
                .WithMany()
                .HasForeignKey(x => x.ParentId);

            builder.ToTable("Material");
        }
    }
}