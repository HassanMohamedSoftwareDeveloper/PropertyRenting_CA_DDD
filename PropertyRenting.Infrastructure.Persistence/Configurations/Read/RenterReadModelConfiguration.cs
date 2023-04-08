using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Enums;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class RenterReadModelConfiguration : IEntityTypeConfiguration<RenterReadModel>
{
    public void Configure(EntityTypeBuilder<RenterReadModel> builder)
    {
        builder.ToTable(TableNames.Renters, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.IdentityType).HasConversion<EnumConverter<IdentityType>>().HasColumnName("IdentityTypeId");
        builder.Property(x => x.RenterType).HasConversion<EnumConverter<RenterType>>().HasColumnName("RenterTypeId");
        builder.Property(x => x.Gender).HasConversion<EnumConverter<Gender>>().HasColumnName("GenderId");

        builder.HasMany(x => x.ContactPeople).WithOne(x => x.Renter).HasForeignKey(x => x.RenterId);
        builder.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId);
        builder.HasOne(x => x.Nationality).WithMany().HasForeignKey(x => x.NationalityId);

    }
}
