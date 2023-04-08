using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence.Services;

internal abstract class BaseReadSevice
{
    protected BaseReadSevice(PropertyRentingReadContext context)
    {
        Context = context;
    }

    protected PropertyRentingReadContext Context { get; }
}
