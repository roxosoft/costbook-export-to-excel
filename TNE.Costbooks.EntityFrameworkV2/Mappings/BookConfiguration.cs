using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNE.Domain.Entities;

namespace TNE.Domain.EntityFrameworkV2.Mappings
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.FirstPage).HasColumnName("FirstPage");
            builder.Property(x => x.ImportDate).HasColumnName("ImportDate");

            builder.ToTable("Book");
        }
    }
}