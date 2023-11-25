using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class OfficialConfiguration : IEntityTypeConfiguration<Official>
    {
        public void Configure(EntityTypeBuilder<Official> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
