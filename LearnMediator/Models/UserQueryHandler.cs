using LearnMediator.Abstractions;
using MediatR;

namespace LearnMediator.Models
{
    public class UserQueryHandler : IQueryHandler<UserQuery, User>
    {
        private readonly FakeStoreData _storeData;

        public UserQueryHandler(FakeStoreData storeData) => _storeData = storeData;

        public async Task<Result<User>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var user = await _storeData.GetUserById(request.Id);
            return user switch
            {
                null => Result.Failure<User>(new Error("User.NotFound", $"The User with Id {request.Id} was not Found")),
                _ => Result.Success(user)
            };
        }
    }
}
