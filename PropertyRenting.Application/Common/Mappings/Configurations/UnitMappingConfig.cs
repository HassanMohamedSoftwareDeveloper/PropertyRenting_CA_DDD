using Mapster;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Common.Mappings.Configurations;

internal sealed class UnitMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UnitReadModel, UnitReadDTO>()
            .Map(dest => dest.District, src => src.District.Name)
            .Map(dest => dest.City, src => src.District.City.Name)
            .Map(dest => dest.Country, src => src.District.City.Country.Name)
            .Map(dest => dest.BuildingCode, src => src.Building.Symbol)
            .Map(dest => dest.BuildingName, src => src.Building.Name);

        config.NewConfig<UnitReadModel, UnitDTO>()
            .Map(dest => dest.DistrictId, src => src.DistrictId)
            .Map(dest => dest.CityId, src => src.District.CityId)
            .Map(dest => dest.CountryId, src => src.District.City.CountryId);

        config.NewConfig<UnitReadModel, BaseLookupDTO>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Description, src => $"{src.UnitNumber} - {src.UnitName}");
    }
}