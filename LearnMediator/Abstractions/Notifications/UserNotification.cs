using LearnMediator.Models;
using MediatR;

namespace LearnMediator.Abstractions.Notifications
{
    public record UserNotification(User User) : INotification;
}
