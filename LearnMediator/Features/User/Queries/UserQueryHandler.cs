using LearnMediator.Abstractions.Errors;
using LearnMediator.Abstractions.Queries;
using LearnMediator.Abstractions.Shared.Results;
using LearnMediator.Repositories.UserRepository;

namespace LearnMediator.Features.User.Queries
{
    public class UserQueryHandler : IQueryHandler<GetUserByIdQuery, Models.User?>
    {
        private readonly FakeStoreData _storeData;

        public UserQueryHandler(FakeStoreData storeData) => _storeData = storeData;

        public async Task<Result<Models.User?>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _storeData.GetUserById(request.Id);
            return user is null
                ? Result.Failure<Models.User>(new Error("User.NotFound", $"The User with Id {request.Id} was not Found"))
                : Result.Success(user);
        }
    }
}
