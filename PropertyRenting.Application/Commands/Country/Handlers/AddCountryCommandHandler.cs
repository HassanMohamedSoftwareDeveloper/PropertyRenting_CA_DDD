namespace PropertyRenting.Application.Commands.Country.Handlers;

public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, ErrorOr<bool>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryReadService _countryReadService;

    public AddCountryCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork, ICountryReadService countryReadService)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
        _countryReadService = countryReadService;
    }
    public async Task<ErrorOr<bool>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
    {
        var countryName = CountryName.Create(request.Name);
        var nationality = Nationality.Create(request.Nationality);

        var isInValid = ValidatorBuilder.Init().Append(countryName).Append(nationality).IsInValid(out List<Error> Errors);

        if (isInValid) return Errors;

        var countryRes = await Domain.Aggregates.Country.Create(countryName.Value, nationality.Value, _countryReadService);

        if (countryRes.IsError) return countryRes.FirstError;

        _countryRepository.Create(countryRes.Value);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
