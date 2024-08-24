
using Throw;

namespace LearnMediator.Models;

public class User
{
    public User(string name, string email)
    {
        (Name, Email) = Validate(name, email);
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public void SetName(string name) =>
        Name = ValidateName(name);

    private static (string name, string email) Validate(string name, string email)
    {
        ValidateName(name);
        ValidateEmail(email);

        return (name, email);
    }

    private static void ValidateEmail(string email) =>
        email.Throw()
            .IfEmpty()
            .IfLongerThan(60)
            .IfShorterThan(2);

    private static string ValidateName(string name) =>
        name.Throw()
            .IfEmpty()
            .IfLongerThan(60)
            .IfShorterThan(2);
}