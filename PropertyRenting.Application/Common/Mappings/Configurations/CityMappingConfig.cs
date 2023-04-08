using Mapster;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Common.Mappings.Configurations;

internal sealed class CityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CityReadModel, CityReadDTO>()
             .Map(dest => dest.CityId, src => src.Id)
             .Map(dest => dest.CityName, src => src.Name)
             .Map(dest => dest.CountryName, src => src.Country.Name);

        config.NewConfig<CityReadModel, CityDTO>()
            .Map(dest => dest.CityId, src => src.Id)
            .Map(dest => dest.CityName, src => src.Name);

        config.NewConfig<CityReadModel, BaseLookupDTO>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Description, src => src.Name);
    }
}
