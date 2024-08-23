using LearnMediator.Abstractions.Errors;
using LearnMediator.Abstractions.Queries;
using LearnMediator.Abstractions.Shared.Results;
using LearnMediator.Repositories.UserRepository;

namespace LearnMediator.Features.User.Queries
{
    public class UsersHandler : IQueryHandler<GetUsersListQuery, IEnumerable<Models.User>>
    {
        private readonly FakeStoreData _storeData;

        public UsersHandler(FakeStoreData storeData) => _storeData = storeData;

        public async Task<Result<IEnumerable<Models.User>>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Models.User> users = await _storeData.GetUsersAsync();
            if (users is null)
            {
                return Result.Failure<IEnumerable<Models.User>>(new Error("User.NotFound", "No members in the record"));
            }
            return Result.Success(users);
        }
    }
}
