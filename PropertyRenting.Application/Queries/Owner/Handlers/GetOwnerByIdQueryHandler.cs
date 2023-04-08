using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Repositories.Read;
using PropertyRenting.Application.Specifications.Read.Owner;

namespace PropertyRenting.Application.Queries.Owner.Handlers;

internal sealed class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, ErrorOr<OwnerDTO>>
{
    private readonly IOwnerReadRepository _ownerReadRepository;

    public GetOwnerByIdQueryHandler(IOwnerReadRepository ownerReadRepository)
    {
        _ownerReadRepository = ownerReadRepository;
    }
    public async Task<ErrorOr<OwnerDTO>> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _ownerReadRepository.GetByIdAsync<OwnerDTO>(new GetOwnerByIdSpecification(request.OwnerId), cancellationToken);
        if (data is null) return Errors.Queries.NotFound;
        return data;
    }
}
