using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Unit;

namespace PropertyRenting.Application.Queries.Unit.Handlers;

internal sealed class GetActiveUnitsLookupQueryHandler : IRequestHandler<GetActiveUnitsLookupQuery, ErrorOr<List<BaseLookupDTO>>>
{
    private readonly IUnitReadRepository _unitReadRepository;

    public GetActiveUnitsLookupQueryHandler(IUnitReadRepository unitReadRepository)
    {
        _unitReadRepository = unitReadRepository;
    }
    public async Task<ErrorOr<List<BaseLookupDTO>>> Handle(GetActiveUnitsLookupQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitReadRepository.GetLookupAsync<BaseLookupDTO>(new GetActiveUnitsLookupSpecification(), cancellationToken);
        if (data is null || data.Count == 0) return Errors.Queries.NoData;
        return data;
    }
}

