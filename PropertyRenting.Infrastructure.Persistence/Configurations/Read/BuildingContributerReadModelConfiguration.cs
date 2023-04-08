using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class BuildingContributerReadModelConfiguration : IEntityTypeConfiguration<BuildingContributerReadModel>
{
    public void Configure(EntityTypeBuilder<BuildingContributerReadModel> builder)
    {
        builder.ToTable(TableNames.BuildingContributers, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Contributer).WithMany().HasForeignKey(x => x.ContributerId);
    }
}
