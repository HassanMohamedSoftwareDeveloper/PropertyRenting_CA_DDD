using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.ValueObjects.Country;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Write;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(TableNames.Countries, DbSchemas.Lookup);
        builder.HasKey(x => x.Id);

        var nameConverter = new ValueConverter<CountryName, string>(x => x.Value, x => CountryName.Create(x).Value);
        var nationalityConverter = new ValueConverter<Nationality, string>(x => x.Value, x => Nationality.Create(x).Value);

        builder.Property(x => x.Name).HasConversion(nameConverter);
        builder.Property(x => x.Nationality).HasConversion(nationalityConverter);
    }
}
