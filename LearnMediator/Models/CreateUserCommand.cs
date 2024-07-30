using MediatR;

namespace LearnMediator.Models
{
    public class CreateUserCommand : IRequest<User>
    {
        private readonly User _user;
        public User User => _user;
        public CreateUserCommand(User user)
        {
            _user = user;
        }
    }
}
