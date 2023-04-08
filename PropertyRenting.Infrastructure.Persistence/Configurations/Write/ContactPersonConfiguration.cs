using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.Entities.Renter;
using PropertyRenting.Domain.Enums;
using PropertyRenting.Domain.ValueObjects.Renter;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Write;

internal sealed class ContactPersonConfiguration : IEntityTypeConfiguration<ContactPerson>
{
    public void Configure(EntityTypeBuilder<ContactPerson> builder)
    {
        builder.ToTable(TableNames.ContactPeople, DbSchemas.Lookup);
        builder.HasKey(x => x.Id);

        var nameConverter = new ValueConverter<ContactPersonName, string>(x => x.Value, x => ContactPersonName.Create(x).Value);

        builder.Property(x => x.Name).HasConversion(nameConverter);

        builder.OwnsOne(x => x.Identity, a =>
        {
            a.Property(p => p.IdentityType).HasConversion<EnumConverter<IdentityType>>().HasColumnName("IdentityTypeId");
            a.Property(p => p.IdentityNumber).HasColumnName("IdentityNumber");
            a.Property(p => p.IdentityIssuePlace).HasColumnName("IdentityIssuePlace");
            a.Property(p => p.IdentityExpiryDate).HasColumnName("IdentityExpiryDate");
        });
    }
}
