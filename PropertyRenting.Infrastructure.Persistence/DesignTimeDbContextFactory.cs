using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PropertyRentingWriteContext>
{
    public PropertyRentingWriteContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PropertyRentingWriteContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PropertyRenting_DB;User Id=sa;Password=Dodohm@1234;");

        return new PropertyRentingWriteContext(optionsBuilder.Options);
    }
}
