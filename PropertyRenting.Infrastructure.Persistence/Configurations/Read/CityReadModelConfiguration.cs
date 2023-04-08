using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class CityReadModelConfiguration : IEntityTypeConfiguration<CityReadModel>
{
    public void Configure(EntityTypeBuilder<CityReadModel> builder)
    {
        builder.ToTable(TableNames.Cities, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Districts).WithOne(x => x.City).HasForeignKey(x => x.CityId);
    }
}
