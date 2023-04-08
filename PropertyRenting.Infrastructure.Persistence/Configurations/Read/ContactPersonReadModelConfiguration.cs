using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Enums;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class ContactPersonReadModelConfiguration : IEntityTypeConfiguration<ContactPersonReadModel>
{
    public void Configure(EntityTypeBuilder<ContactPersonReadModel> builder)
    {
        builder.ToTable(TableNames.ContactPeople, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.IdentityType).HasConversion<EnumConverter<IdentityType>>().HasColumnName("IdentityTypeId");
    }
}
