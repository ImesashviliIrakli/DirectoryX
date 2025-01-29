using Domain.Abstractions;
using MediatR;

namespace Application.Abstractions.Messaging;

public interface ICommandQuery : IRequest<Result>, IBaseRequest
{
}
