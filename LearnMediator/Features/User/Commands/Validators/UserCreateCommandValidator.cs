using FluentValidation;
using LearnMediator.Repositories.UserRepository;

namespace LearnMediator.Features.User.Commands.Validators
{
    public class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateCommandValidator(FakeStoreData storeData)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(2, 60)
                .Must(name => !name.StartsWith("universitat oberta de", StringComparison.InvariantCultureIgnoreCase))
                .WithMessage("This name is forbidden...");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(async (email, ct) => await storeData.GetUserByEmail(email, ct) is null)
                .WithMessage(cmd => $"Email address {cmd.Email} is already in use");
        }
    }
}
