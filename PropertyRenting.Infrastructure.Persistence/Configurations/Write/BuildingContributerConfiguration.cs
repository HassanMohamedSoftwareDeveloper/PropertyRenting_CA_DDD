using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Domain.Entities.Building;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Write;

internal sealed class BuildingContributerConfiguration : IEntityTypeConfiguration<BuildingContributer>
{
    public void Configure(EntityTypeBuilder<BuildingContributer> builder)
    {
        builder.ToTable(TableNames.BuildingContributers, DbSchemas.Lookup);
        builder.HasKey(x => x.Id);

        // builder.Property<EntityId>("BuildingId");
        //builder.HasOne<Building>().WithMany("_contributers").OnDelete(DeleteBehavior.Cascade);
    }
}