using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class SubmitionConfiguration : IEntityTypeConfiguration<Submition>
    {
        public void Configure(EntityTypeBuilder<Submition> builder)
        {
            builder.OwnsOne(e => e.FieldAddress);
        }
    }
}
