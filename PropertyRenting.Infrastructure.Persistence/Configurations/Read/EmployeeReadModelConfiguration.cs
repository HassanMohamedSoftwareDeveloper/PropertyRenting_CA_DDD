using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Infrastructure.Persistence.Constants;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Read;

internal sealed class EmployeeReadModelConfiguration : IEntityTypeConfiguration<EmployeeReadModel>
{
    public void Configure(EntityTypeBuilder<EmployeeReadModel> builder)
    {
        builder.ToTable(TableNames.Employees, DbSchemas.Lookup);

        builder.HasKey(x => x.Id);
    }
}