using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.ValueObjects.Contributer;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Write;

internal sealed class ContributerConfiguration : IEntityTypeConfiguration<Contributer>
{
    public void Configure(EntityTypeBuilder<Contributer> builder)
    {
        builder.ToTable(TableNames.Contributers, DbSchemas.Lookup);
        builder.HasKey(x => x.Id);

        var nameConverter = new ValueConverter<ContributerName, string>(x => x.Value, x => ContributerName.Create(x).Value);

        builder.Property(x => x.Name).HasConversion(nameConverter);
    }
}
