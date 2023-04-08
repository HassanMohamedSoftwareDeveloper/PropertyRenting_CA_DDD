using Mapster;

namespace PropertyRenting.Presentation.Endpoints.Country.Commands.Update;


internal sealed class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Request, UpdateCountryCommand>()
            .Map(dest => dest.CountryId, src => src.Id);
    }

}