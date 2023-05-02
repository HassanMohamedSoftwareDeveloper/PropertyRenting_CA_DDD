using Microsoft.EntityFrameworkCore;
using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Entities.Building;
using PropertyRenting.Domain.Entities.Country;
using PropertyRenting.Domain.Entities.Renter;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Configurations.Read;

namespace PropertyRenting.Infrastructure.Persistence.Contexts;

public class PropertyRentingWriteContext : DbContext
{
    #region CTORS :
    public PropertyRentingWriteContext(DbContextOptions<PropertyRentingWriteContext> options) : base(options)
    {
    }
    #endregion

    #region PROPS :

    #region Lookups :
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Contributer> Contributers { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<BuildingContributer> BuildingContributers { get; set; }
    public DbSet<Renter> Renters { get; set; }
    public DbSet<ContactPerson> ContactPeople { get; set; }
    #endregion

    #endregion

    #region Methods :
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuildingReadModelConfiguration).Assembly, x => x.Namespace == "PropertyRenting.Infrastructure.Persistence.Configurations.Write");
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>().HaveColumnType("date");
        configurationBuilder.Properties<EntityId>().HaveConversion<EntityIdConverter>();
        configurationBuilder.Properties<PhoneNumber>().HaveConversion<PhoneNumberConverter>();
        configurationBuilder.Properties<MobileNumber>().HaveConversion<MobileNumberConverter>();
        configurationBuilder.Properties<EmailAddress>().HaveConversion<EmailAddressConverter>();
        configurationBuilder.Properties<Percentage>().HaveConversion<PercentageConverter>();
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal").HavePrecision(20, 4);
    }
    #endregion
}

