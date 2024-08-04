using MediatR;

namespace LearnMediator.Models
{
    public record UserNotification(User User) : INotification;
}
