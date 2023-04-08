using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;

internal class EnumConverter<TEnum> : ValueConverter<TEnum, int> where TEnum : Enumeration<TEnum>
{
    public EnumConverter() : base(x => x.Value, x => Enumeration<TEnum>.FromValue(x))
    { }
}
