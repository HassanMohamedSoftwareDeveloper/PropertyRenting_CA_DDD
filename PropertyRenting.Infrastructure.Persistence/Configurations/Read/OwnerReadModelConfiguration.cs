using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class OwnerReadModelConfiguration : IEntityTypeConfiguration<OwnerReadModel>
{
    public void Configure(EntityTypeBuilder<OwnerReadModel> builder)
    {
        builder.ToTable(TableNames.Owners, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);
    }
}
