using LearnMediator.Abstractions.Shared.Results;
using MediatR;

namespace LearnMediator.Abstractions.Queries;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
{

}