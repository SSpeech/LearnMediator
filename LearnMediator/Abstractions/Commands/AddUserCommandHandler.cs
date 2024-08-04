using LearnMediator.Abstractions.Shared.Results;
using LearnMediator.Models;
using LearnMediator.Repositories.UserRepository;
using MediatR;

namespace LearnMediator.Abstractions.Commands
{
    public class AddUserCommandHandler : ICommandHandler<CreateUserCommand, User>
    {
        private readonly FakeStoreData _storeData;

        public AddUserCommandHandler(FakeStoreData storeData) => _storeData = storeData;
        public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _storeData.AddUser(request.User);
            return Result.Success(request.User);
        }
    }
}