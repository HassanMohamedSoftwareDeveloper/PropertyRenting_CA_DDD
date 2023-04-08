using Microsoft.EntityFrameworkCore;
using PropertyRenting.Domain.Aggregates;
using PropertyRenting.Domain.Entities.Building;
using PropertyRenting.Domain.Entities.Country;
using PropertyRenting.Domain.Entities.Renter;
using PropertyRenting.Domain.ValueObjects.Common;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Configurations.Write;

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
        modelBuilder.ApplyConfiguration(new BuildingConfiguration());
        modelBuilder.ApplyConfiguration(new BuildingContributerConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new ContactPersonConfiguration());
        modelBuilder.ApplyConfiguration(new ContributerConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new DistrictConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new OwnerConfiguration());
        modelBuilder.ApplyConfiguration(new RenterConfiguration());
        modelBuilder.ApplyConfiguration(new UnitConfiguration());
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuildingConfiguration).Assembly);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>().HaveColumnType("date");
        builder.Properties<EntityId>().HaveConversion<EntityIdConverter>();
        builder.Properties<PhoneNumber>().HaveConversion<PhoneNumberConverter>();
        builder.Properties<MobileNumber>().HaveConversion<MobileNumberConverter>();
        builder.Properties<EmailAddress>().HaveConversion<EmailAddressConverter>();
        builder.Properties<Percentage>().HaveConversion<PercentageConverter>();
        builder.Properties<decimal>().HaveColumnType("decimal").HavePrecision(20, 4);
    }
    #endregion
}

