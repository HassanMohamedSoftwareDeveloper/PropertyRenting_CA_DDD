using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.Entities.Country;
using PropertyRenting.Domain.ValueObjects.Country;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Write;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable(TableNames.Districts, DbSchemas.Lookup);
        builder.HasKey(x => x.Id);

        var nameConverter = new ValueConverter<DistrictName, string>(x => x.Value, x => DistrictName.Create(x).Value);

        builder.Property(x => x.Name).HasConversion(nameConverter);

        //builder.Property<EntityId>("CityId");
        //builder.HasOne<City>().WithMany("_districts").HasForeignKey("CityId").OnDelete(DeleteBehavior.Cascade);
    }
}
