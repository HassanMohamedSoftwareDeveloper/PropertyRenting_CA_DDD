using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.Entities.Building;
using PropertyRenting.Domain.ValueObjects.Building;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Write;

internal sealed class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable(TableNames.Units, DbSchemas.Lookup);
        builder.HasKey(x => x.Id);

        var unitNumberConverter = new ValueConverter<UnitNumber, string>(x => x.Value, x => UnitNumber.Create(x).Value);
        var nameConverter = new ValueConverter<UnitName, string>(x => x.Value, x => UnitName.Create(x).Value);

        builder.Property(x => x.UnitNumber).HasConversion(unitNumberConverter);
        builder.Property(x => x.UnitName).HasConversion(nameConverter);

        //  builder.Property<EntityId>("BuildingId");
        //  builder.HasOne<Building>().WithMany("_units").OnDelete(DeleteBehavior.Cascade);
    }
}
