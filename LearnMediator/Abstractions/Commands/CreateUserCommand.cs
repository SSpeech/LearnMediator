using LearnMediator.Models;
using MediatR;
using System.Windows.Input;
using ICommand = LearnMediator.Abstractions.Commands.ICommand;

namespace LearnMediator.Abstractions.Commands
{
    public class CreateUserCommand : ICommand<User>
    {
        private readonly User _user;
        public User User => _user;
        public CreateUserCommand(User user) => _user = user;
    }
}
