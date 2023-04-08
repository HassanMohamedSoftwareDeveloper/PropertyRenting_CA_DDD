namespace PropertyRenting.Contracts.Requests;

public record CreateCountryRequest(string CountryName, string Nationality);
public record UpdateCountryRequest(Guid CountryId, string CountryName, string Nationality);