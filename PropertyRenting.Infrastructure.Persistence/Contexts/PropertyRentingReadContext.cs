using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;
using PropertyRenting.Infrastructure.Persistence.Configurations.Read;

namespace PropertyRenting.Infrastructure.Persistence.Contexts;

internal class PropertyRentingReadContext : DbContext
{
    #region CTORS :
    public PropertyRentingReadContext(DbContextOptions<PropertyRentingReadContext> options) : base(options)
    {
    }
    #endregion

    #region PROPS :

    #region Lookups :
    public DbSet<CountryReadModel> Countries { get; set; }
    public DbSet<CityReadModel> Cities { get; set; }
    public DbSet<DistrictReadModel> Districts { get; set; }
    public DbSet<OwnerReadModel> Owners { get; set; }
    public DbSet<EmployeeReadModel> Employees { get; set; }
    public DbSet<ContributerReadModel> Contributers { get; set; }
    public DbSet<BuildingReadModel> Buildings { get; set; }
    public DbSet<UnitReadModel> Units { get; set; }
    public DbSet<BuildingContributerReadModel> BuildingContributers { get; set; }
    public DbSet<RenterReadModel> Renters { get; set; }
    public DbSet<ContactPersonReadModel> ContactPeople { get; set; }
    #endregion

    #endregion

    #region Methods :
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuildingReadModelConfiguration).Assembly, x => x.Namespace == "PropertyRenting.Infrastructure.Persistence.Configurations.Read");
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>().HaveColumnType("date");
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal").HavePrecision(20, 4);
    }
    #endregion
}
