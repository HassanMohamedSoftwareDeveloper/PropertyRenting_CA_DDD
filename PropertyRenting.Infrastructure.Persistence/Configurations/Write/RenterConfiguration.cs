using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Enums;
using PropertyRenting.Domain.ValueObjects.Renter;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Write;

internal sealed class RenterConfiguration : IEntityTypeConfiguration<Renter>
{
    public void Configure(EntityTypeBuilder<Renter> builder)
    {
        builder.ToTable(TableNames.Renters, DbSchemas.Lookup);
        builder.HasKey(x => x.Id);

        var nameConverter = new ValueConverter<RenterName, string>(x => x.Value, x => RenterName.Create(x).Value);

        builder.Property(x => x.RenterType).HasConversion<EnumConverter<RenterType>>().HasColumnName("RenterTypeId");
        builder.Property(x => x.Gender).HasConversion<EnumConverter<Gender>>().HasColumnName("GenderId");
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
