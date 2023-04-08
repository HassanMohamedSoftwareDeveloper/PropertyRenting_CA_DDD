using PropertyRenting.Application.Specifications.Write.Country;

namespace PropertyRenting.Application.Commands.District.Handlers;

public class DeleteDistrictCommandHandler : IRequestHandler<DeleteDistrictCommand, ErrorOr<bool>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryReadService _countryReadService;

    public DeleteDistrictCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork, ICountryReadService countryReadService)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
        _countryReadService = countryReadService;
    }
    public async Task<ErrorOr<bool>> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
    {
        var countryId = EntityId.Create(request.CountryId);
        var cityId = EntityId.Create(request.CityId);
        var districtId = EntityId.Create(request.DistrictId);


        var inInvalid = ValidatorBuilder.Init().Append(countryId).Append(cityId).Append(districtId).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;


        var country = await _countryRepository.GetCountryAsync(new GetCountryWithCitiesAndDistrictsSpecification(countryId.Value, cityId.Value), cancellationToken);
        if (country is null) return Domain.Errors.Errors.Common.NotFoundEntity;


        var res = await country.RemoveDistrict(cityId.Value, districtId.Value, _countryReadService);
        if (res.IsError) return res.FirstError;

        _countryRepository.Update(country);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
