namespace PropertyRenting.Application.Commands.Country.Handlers;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, ErrorOr<bool>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryReadService _countryReadService;

    public UpdateCountryCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork, ICountryReadService countryReadService)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
        _countryReadService = countryReadService;
    }
    public async Task<ErrorOr<bool>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var countryId = EntityId.Create(request.CountryId);
        var countryName = CountryName.Create(request.Name);
        var nationality = Nationality.Create(request.Nationality);


        var isInValid = ValidatorBuilder.Init().Append(countryId).Append(countryName).Append(nationality).IsInValid(out List<Error> ErrorList);

        if (isInValid) return ErrorList;

        var country = await _countryRepository.GetEntityByIdAsync(countryId.Value, cancellationToken);
        if (country is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        var updateRes = await country.Update(countryName.Value, nationality.Value, _countryReadService);
        if (updateRes.IsError) return updateRes.FirstError;

        _countryRepository.Update(country);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
