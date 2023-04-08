using Mapster;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Common.Mappings.Configurations;

internal sealed class DistrictMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DistrictReadModel, DistrictReadDTO>()
             .Map(dest => dest.CityName, src => src.City.Name)
             .Map(dest => dest.CountryName, src => src.City.Country.Name);

        config.NewConfig<DistrictReadModel, DistrictDTO>()
            .Map(dest => dest.CountryId, src => src.City.CountryId);

        config.NewConfig<DistrictReadModel, BaseLookupDTO>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Description, src => src.Name);
    }
}
