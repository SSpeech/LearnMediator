using FluentValidation;
using LearnMediator.Models;
using LearnMediator.Repositories.UserRepository;

namespace LearnMediator.Abstractions.Commands.CommandValidations
{
    public class UserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly FakeStoreData _storeData;


        public UserCommandValidator(FakeStoreData storeData)
        {
            _storeData = storeData;
            RuleFor(x => x.User.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.User.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(60)
                .MaximumLength(2);
            RuleFor(x => x.User.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (int id, CancellationToken cancellationToken) =>
                {
                    var user = await _storeData!.GetUserById(id);
                    return user is null;
                })
                .WithMessage("User ID already exists");
        }
    }
}
