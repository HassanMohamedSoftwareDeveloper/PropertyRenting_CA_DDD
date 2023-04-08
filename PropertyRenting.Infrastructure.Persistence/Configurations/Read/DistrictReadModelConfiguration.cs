using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class DistrictReadModelConfiguration : IEntityTypeConfiguration<DistrictReadModel>
{
    public void Configure(EntityTypeBuilder<DistrictReadModel> builder)
    {
        builder.ToTable(TableNames.Districts, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);
    }
}
