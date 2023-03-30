using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class CrewCompositionConfiguration : IEntityTypeConfiguration<CrewComposition>
    {
        public void Configure(EntityTypeBuilder<CrewComposition> builder)
        {
            builder.ToTable("CrewComposition");
        }
    }
}