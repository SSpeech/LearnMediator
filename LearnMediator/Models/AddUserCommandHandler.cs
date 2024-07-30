using MediatR;

namespace LearnMediator.Models
{
    public class AddUserCommandHandler : IRequestHandler<CreateUserCommand,User>
    {
        private readonly FakeStoreData _storeData;

        public AddUserCommandHandler(FakeStoreData storeData)
        {
            _storeData = storeData;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _storeData.AddUser(request.User);
            return request.User;
        }
    }
}