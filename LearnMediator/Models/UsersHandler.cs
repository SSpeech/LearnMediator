using LearnMediator.Abstractions;
using MediatR;

namespace LearnMediator.Models
{
    public class UsersHandler : IQueryHandler<UsersQuery,IEnumerable<User>>
    {
        private readonly FakeStoreData _storeData;

        public UsersHandler(FakeStoreData storeData) => _storeData = storeData;

        public async Task<Result<IEnumerable<User>>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _storeData.GetUsersAsync();
            if (users is null)
            {
                return Result.Failure<IEnumerable<User>>(new Error("User.NotFound", "No members in the record"));
            }   
            return Result.Success(users);
        }
    }
}
