using PropertyRenting.Application.Specifications.Write.Country;

namespace PropertyRenting.Application.Commands.City.Handlers;

public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, ErrorOr<bool>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryReadService _countryReadService;

    public DeleteCityCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork, ICountryReadService countryReadService)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
        _countryReadService = countryReadService;
    }
    public async Task<ErrorOr<bool>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var countryId = EntityId.Create(request.CountryId);
        var cityId = EntityId.Create(request.CityId);

        var inInvalid = ValidatorBuilder.Init().Append(countryId).Append(cityId).IsInValid(out List<Error> ErrorList);
        if (inInvalid) return ErrorList;


        var country = await _countryRepository.GetCountryAsync(new GetCountryWithCitiesSpecifications(countryId.Value), cancellationToken);
        if (country is null) return Domain.Errors.Errors.Common.NotFoundEntity;


        var res = await country.RemoveCity(cityId.Value, _countryReadService);
        if (res.IsError) return res.FirstError;

        _countryRepository.Update(country);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
