using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class ContributerReadModelConfiguration : IEntityTypeConfiguration<ContributerReadModel>
{
    public void Configure(EntityTypeBuilder<ContributerReadModel> builder)
    {
        builder.ToTable(TableNames.Contributers, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);
    }
}
