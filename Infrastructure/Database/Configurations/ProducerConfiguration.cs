using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(e => e.FarmAddress);
            builder.HasMany(e => e.Submitions)
                .WithOne(e => e.Producer)
                .HasForeignKey(e => e.ProducerId)
                .IsRequired();
        }
    }
}
