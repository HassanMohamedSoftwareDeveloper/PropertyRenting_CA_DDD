using Mapster;
using PropertyRenting.Application.Commands.District;

namespace PropertyRenting.API.Endpoints.District.Commands.Add;

internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, AddDistrictCommand>();
    }
}
