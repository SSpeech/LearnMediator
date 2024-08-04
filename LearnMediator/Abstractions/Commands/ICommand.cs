using LearnMediator.Abstractions.Shared.Results;
using MediatR;

namespace LearnMediator.Abstractions.Commands
{
    public interface ICommand : IRequest<Result>
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
