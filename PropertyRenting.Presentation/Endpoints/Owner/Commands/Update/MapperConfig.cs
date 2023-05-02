using Mapster;
using PropertyRenting.Application.Commands.Owner;

namespace PropertyRenting.API.Endpoints.Owner.Commands.Update;


internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, UpdateOwnerCommand>();
    }

}