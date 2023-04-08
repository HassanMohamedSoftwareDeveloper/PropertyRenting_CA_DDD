using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;

internal class MobileNumberConverter : ValueConverter<MobileNumber, string>
{
    public MobileNumberConverter()
        : base(x => x.Value, x => MobileNumber.Create(x).Value)
    {
    }
}
