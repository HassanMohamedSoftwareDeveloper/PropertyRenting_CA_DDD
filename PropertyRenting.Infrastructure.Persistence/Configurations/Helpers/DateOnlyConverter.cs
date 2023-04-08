using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;

internal class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(d => d.ToDateTime(TimeOnly.MinValue), d => DateOnly.FromDateTime(d))
    { }
}

