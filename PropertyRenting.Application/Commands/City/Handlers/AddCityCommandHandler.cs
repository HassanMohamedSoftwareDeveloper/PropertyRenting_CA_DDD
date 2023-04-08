﻿using PropertyRenting.Application.Specifications.Write.Country;

namespace PropertyRenting.Application.Commands.City.Handlers;

public class AddCityCommandHandler : IRequestHandler<AddCityCommand, ErrorOr<bool>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCityCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<bool>> Handle(AddCityCommand request, CancellationToken cancellationToken)
    {
        var countryId = EntityId.Create(request.CountryId);
        var cityName = CityName.Create(request.Name);

        var inInvalid = ValidatorBuilder.Init().Append(countryId).Append(cityName).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;

        var country = await _countryRepository.GetCountryAsync(new GetCountryWithCitiesSpecifications(countryId.Value), cancellationToken);
        if (country is null) return Domain.Errors.Errors.Common.NotFoundEntity;


        country.AddCity(cityName.Value);
        _countryRepository.Update(country);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
