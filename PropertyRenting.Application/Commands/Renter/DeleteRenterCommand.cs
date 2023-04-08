using ErrorOr;
using MediatR;

namespace PropertyRenting.Application.Commands.Renter;

public record DeleteRenterCommand(Guid RenterId) : IRequest<ErrorOr<bool>>;
