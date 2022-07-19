
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ditto.Data.Configuration;

public class DittoConfiguration : IEntityTypeConfiguration<Ditto.Common.Domain.Ditto>
{
    public void Configure(EntityTypeBuilder<Common.Domain.Ditto> builder)
    {
        builder.Property(d => d.Name).HasMaxLength(50).IsRequired();
        builder.Property(d => d.FrecuencyTime).IsRequired();
        builder.Property(d => d.Frecuency).HasMaxLength(15).IsRequired().HasConversion<string>();
        builder.Property(d => d.CalendarEventId).HasMaxLength(100);
    }
}
