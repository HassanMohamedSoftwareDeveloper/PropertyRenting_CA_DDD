using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;

internal class EmailAddressConverter : ValueConverter<EmailAddress, string>
{
    public EmailAddressConverter()
        : base(x => x.Value, x => EmailAddress.Create(x).Value)
    {
    }
}
