using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;

internal class PercentageConverter : ValueConverter<Percentage, decimal>
{
    public PercentageConverter()
        : base(x => x.Value, x => Percentage.Create(x).Value)
    {
    }
}