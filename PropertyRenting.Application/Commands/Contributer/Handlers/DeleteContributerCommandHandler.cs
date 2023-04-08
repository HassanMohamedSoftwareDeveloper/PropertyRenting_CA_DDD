namespace PropertyRenting.Application.Commands.Contributer.Handlers;

public class DeleteContributerCommandHandler : IRequestHandler<DeleteContributerCommand, ErrorOr<bool>>
{
    private readonly IContributerRepository _contributerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContributerCommandHandler(IContributerRepository contributerRepository, IUnitOfWork unitOfWork)
    {
        _contributerRepository = contributerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteContributerCommand request, CancellationToken cancellationToken)
    {
        var id = EntityId.Create(request.ContributerId);
        if (id.IsError) return id.FirstError;


        var contributer = await _contributerRepository.GetEntityByIdAsync(id.Value, cancellationToken);
        if (contributer is null) return Domain.Errors.Errors.Common.NotFoundEntity;

        _contributerRepository.Delete(contributer);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
