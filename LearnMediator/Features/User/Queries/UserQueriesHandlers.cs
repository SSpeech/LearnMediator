using LearnMediator.Abstractions.Errors;
using LearnMediator.Abstractions.Queries;
using LearnMediator.Abstractions.Shared.Results;
using LearnMediator.Repositories.UserRepository;

namespace LearnMediator.Features.User.Queries
{
    public class UserQueriesHandlers(FakeStoreData storeData) : IQueryHandler<GetUserByIdQuery, Models.User>,
                                                                IQueryHandler<GetUsersListQuery, IEnumerable<Models.User>>
    {
        public async Task<Result<Models.User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await storeData.GetUserById(request.Id);
            return user is null
                ? Result.Failure<Models.User>(new Error("User.NotFound", $"The User with Id {request.Id} was not Found"))!
                : Result.Success(user);
        }

        public async Task<Result<IEnumerable<Models.User>>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var item = await storeData.GetUsersAsync();
            return Result.Success(item);
        }
    }
}
