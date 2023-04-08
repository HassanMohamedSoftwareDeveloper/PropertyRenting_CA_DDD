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
        modelBuilder.ApplyConfiguration(new BuildingReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new BuildingContributerReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new CityReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new ContactPersonReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new ContributerReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new CountryReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new DistrictReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new OwnerReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new RenterReadModelConfiguration());
        modelBuilder.ApplyConfiguration(new UnitReadModelConfiguration());
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuildingReadModelConfiguration).Assembly);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>().HaveColumnType("date");
        builder.Properties<decimal>().HaveColumnType("decimal").HavePrecision(20, 4);
    }
    #endregion
}
