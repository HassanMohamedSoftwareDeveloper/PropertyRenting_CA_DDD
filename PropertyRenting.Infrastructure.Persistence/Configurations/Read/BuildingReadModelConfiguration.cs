using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Enums;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class BuildingReadModelConfiguration : IEntityTypeConfiguration<BuildingReadModel>
{
    public void Configure(EntityTypeBuilder<BuildingReadModel> builder)
    {
        builder.ToTable(TableNames.Buildings, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.ConstructionStatus).HasConversion<EnumConverter<ConstructionStatus>>().HasColumnName("ConstructionStatusId");
        builder.Property(x => x.BuildingType).HasConversion<EnumConverter<BuildingType>>().HasColumnName("BuildingTypeId");

        builder.HasMany(x => x.Contributers).WithOne(x => x.Building).HasForeignKey(x => x.BuildingId);
        builder.HasMany(x => x.Units).WithOne(x => x.Building).HasForeignKey(x => x.BuildingId);
        builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId);
        builder.HasOne(x => x.District).WithMany().HasForeignKey(x => x.DistrictId);
    }
}
