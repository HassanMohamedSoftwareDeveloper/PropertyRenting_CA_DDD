using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Enums;
using PropertyRenting.Domain.ValueObjects.Building;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Write;

internal sealed class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.ToTable(TableNames.Buildings, DbSchemas.Lookup);
        builder.HasKey(x => x.Id);

        var symbolConverter = new ValueConverter<BuildingSymbol, string>(x => x.Value, x => BuildingSymbol.Create(x).Value);
        var nameConverter = new ValueConverter<BuildingName, string>(x => x.Value, x => BuildingName.Create(x).Value);

        builder.Property(x => x.Symbol).HasConversion(symbolConverter);
        builder.Property(x => x.Name).HasConversion(nameConverter);
        builder.Property(x => x.Type).HasConversion<EnumConverter<BuildingType>>().HasColumnName("BuildingTypeId");
        builder.Property(x => x.ConstructionStatus).HasConversion<EnumConverter<ConstructionStatus>>().HasColumnName("ConstructionStatusId");
    }
}
