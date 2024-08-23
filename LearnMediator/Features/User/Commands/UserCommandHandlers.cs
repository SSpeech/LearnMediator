using LearnMediator.Abstractions.Commands;
using LearnMediator.Abstractions.Shared.Results;
using LearnMediator.Extensions;
using LearnMediator.Repositories.UserRepository;

namespace LearnMediator.Features.User.Commands
{
    public class UserCommandHandlers : ICommandHandler<UserCreateCommand, Guid>
    {
        private readonly FakeStoreData _storeData;

        public UserCommandHandlers(FakeStoreData storeData) => _storeData = storeData;

        public async Task<Result<Guid>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var item = request.Map();

            await _storeData.AddUser(item);
            return Result.Success(item.Id);
        }
    }
}