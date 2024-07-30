using MediatR;

namespace LearnMediator.Models
{
    public class UserQueryHandler : IRequestHandler<UserQuery, User>
    {
        private readonly FakeStoreData _storeData;

        public UserQueryHandler(FakeStoreData storeData)
        {
            _storeData = storeData;
        }

        public async Task<User> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var user = await _storeData.GetUserById(request.Id);
           return await Task.FromResult(user);
        }
    }
}
