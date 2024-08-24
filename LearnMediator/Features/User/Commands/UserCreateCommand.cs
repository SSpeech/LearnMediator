using LearnMediator.Abstractions.Commands;

namespace LearnMediator.Features.User.Commands;

public class UserCreateCommand : ICommand<Guid>
{
    public UserCreateCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
}