using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Domain.ValueObjects.Common;

namespace PropertyRenting.Infrastructure.Persistence.Configurations.Helpers;

internal class EntityIdConverter : ValueConverter<EntityId, Guid>
{
    public EntityIdConverter()
        : base(x => x.Value, x => EntityId.Create(x).Value)
    {
    }
}
