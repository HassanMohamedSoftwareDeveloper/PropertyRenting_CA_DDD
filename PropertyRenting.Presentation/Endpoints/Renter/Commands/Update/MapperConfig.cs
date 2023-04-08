using Mapster;
using PropertyRenting.Application.Commands.Renter;

namespace PropertyRenting.Presentation.Endpoints.Renter.Commands.Update;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, UpdateRenterCommand>();
    }
}
