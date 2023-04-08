namespace PropertyRenting.Application.Commands.District;

public record AddDistrictCommand(Guid CountryId, Guid CityId, string Name) : IRequest<ErrorOr<bool>>;
