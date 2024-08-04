using LearnMediator.Abstractions;
using MediatR;

namespace LearnMediator.Models
{
    public class AddUserCommandHandler : ICommandHandler<CreateUserCommand,User>
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