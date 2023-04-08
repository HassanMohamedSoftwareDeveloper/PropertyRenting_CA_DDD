using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;

internal class PhoneNumberConverter : ValueConverter<PhoneNumber, string>
{
    public PhoneNumberConverter()
        : base(x => x.Value, x => PhoneNumber.Create(x).Value)
    {
    }
}
