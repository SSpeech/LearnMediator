using LearnMediator.Abstractions.Shared.Results;
using MediatR;

namespace LearnMediator.Abstractions.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
