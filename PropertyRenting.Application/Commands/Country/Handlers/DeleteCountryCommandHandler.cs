namespace PropertyRenting.Application.Commands.Country.Handlers;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, ErrorOr<bool>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryReadService _countryReadService;

    public DeleteCountryCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork, ICountryReadService countryReadService)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
        _countryReadService = countryReadService;
    }
    public async Task<ErrorOr<bool>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var countryId = EntityId.Create(request.CountryId);
        if (countryId.IsError) return countryId.FirstError;

        var country = await _countryRepository.GetEntityByIdAsync(countryId.Value, cancellationToken);
        if (country is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        var canDelete = await _countryReadService.CanDeleteAsync(countryId.Value);
        if (canDelete is false) return Domain.Errors.Errors.Common.HasTransactions;

        _countryRepository.Delete(country);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
