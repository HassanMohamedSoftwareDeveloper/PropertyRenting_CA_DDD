using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class CountryReadModelConfiguration : IEntityTypeConfiguration<CountryReadModel>
{
    public void Configure(EntityTypeBuilder<CountryReadModel> builder)
    {
        builder.ToTable(TableNames.Countries, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Cities).WithOne(x => x.Country).HasForeignKey(x => x.CountryId);
    }
}
