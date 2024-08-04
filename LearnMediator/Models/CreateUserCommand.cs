using LearnMediator.Abstractions;
using MediatR;
using System.Windows.Input;
using ICommand = LearnMediator.Abstractions.ICommand;

namespace LearnMediator.Models
{
    public class CreateUserCommand : ICommand<User>
    {
        private readonly User _user;
        public User User => _user;
        public CreateUserCommand(User user) => _user = user;
    }
}
