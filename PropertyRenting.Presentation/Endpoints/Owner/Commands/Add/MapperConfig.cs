using Mapster;
using PropertyRenting.Application.Commands.Owner;

namespace PropertyRenting.API.Endpoints.Owner.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddOwnerCommand>();
    }

}
