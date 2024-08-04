using LearnMediator.Abstractions;
using MediatR;

namespace LearnMediator.Models;

public interface IQueryHandler<TQuery,TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {

    }