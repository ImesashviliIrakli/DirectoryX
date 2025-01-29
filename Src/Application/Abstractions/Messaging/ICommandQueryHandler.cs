using Domain.Abstractions;
using MediatR;

namespace Application.Abstractions.Messaging;

public interface ICommandQueryHandler<in TRequest> : IRequestHandler<TRequest, Result>
    where TRequest : IRequest<Result>
{
}
