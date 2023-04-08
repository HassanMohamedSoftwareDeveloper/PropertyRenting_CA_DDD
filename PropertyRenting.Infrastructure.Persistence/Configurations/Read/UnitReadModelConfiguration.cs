using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class UnitReadModelConfiguration : IEntityTypeConfiguration<UnitReadModel>
{
    public void Configure(EntityTypeBuilder<UnitReadModel> builder)
    {
        builder.ToTable(TableNames.Units, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.District).WithMany().HasForeignKey(x => x.DistrictId);
    }
}