using MediatR;

namespace LearnMediator.Models
{
    public class UsersHandler : IRequestHandler<UsersQuery, IEnumerable<User>>
    {
        private readonly FakeStoreData _storeData;

        public UsersHandler(FakeStoreData storeData) => _storeData = storeData;

        public async Task<IEnumerable<User>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
           
           return await _storeData.GetUsersAsync();
        }
    }
}
