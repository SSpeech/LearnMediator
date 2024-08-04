using LearnMediator.Abstractions;
using MediatR;

namespace LearnMediator.Models;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
