using PropertyRenting.Application.Specifications.Write.Country;

namespace PropertyRenting.Application.Commands.District.Handlers;

public class UpdateDistrictCommandHandler : IRequestHandler<UpdateDistrictCommand, ErrorOr<bool>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDistrictCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<bool>> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
    {
        var countryId = EntityId.Create(request.CountryId);
        var cityId = EntityId.Create(request.CityId);
        var districtId = EntityId.Create(request.CityId);
        var districtName = DistrictName.Create(request.Name);

        var inInvalid = ValidatorBuilder.Init().Append(countryId).Append(cityId).Append(districtId).Append(districtName).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;

        var country = await _countryRepository.GetCountryAsync(new GetCountryWithCitiesAndDistrictsSpecification(countryId.Value, cityId.Value), cancellationToken);
        if (country is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        country.UpdateDistrict(cityId.Value, districtId.Value, districtName.Value);

        _countryRepository.Update(country);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
