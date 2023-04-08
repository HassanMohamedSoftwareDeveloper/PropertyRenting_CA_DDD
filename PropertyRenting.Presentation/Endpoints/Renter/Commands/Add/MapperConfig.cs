using Mapster;
using PropertyRenting.Application.Commands.Renter;

namespace PropertyRenting.Presentation.Endpoints.Renter.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddRenterCommand>();
    }
}
