using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class CrewConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.Property(x => x.Code).HasColumnName("Code").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.HourlyWadge).HasColumnName("HourlyWadge");
            builder.Ignore(x => x.Name);
            builder.ToTable("Crew");
        }
    }
}