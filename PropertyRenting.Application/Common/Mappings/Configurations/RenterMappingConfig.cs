using Mapster;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;

namespace PropertyRenting.Application.Common.Mappings.Configurations;

internal sealed class RenterMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RenterReadModel, RenterReadDTO>()
            .Map(dest => dest.IdentityType, src => src.IdentityType.Name)
            .Map(dest => dest.Nationality, src => src.Nationality.Nationality)
            .Map(dest => dest.RenterType, src => src.RenterType.Name)
            .Map(dest => dest.City, src => src.City.Name)
            .Map(dest => dest.Country, src => src.City.Country.Name);

        config.NewConfig<RenterReadModel, RenterDTO>()
            .Map(dest => dest.IdentityType, src => src.IdentityType.Value)
            .Map(dest => dest.NationalityId, src => src.NationalityId)
            .Map(dest => dest.RenterType, src => src.RenterType.Value)
            .Map(dest => dest.CountryId, src => src.City.CountryId);

        config.NewConfig<RenterReadModel, BaseLookupDTO>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Description, src => src.Name);

        config.NewConfig<ContactPersonReadModel, ContactPersonDTO>()
            .Map(dest => dest.IdentityType, src => src.IdentityType.Value);
    }
}
