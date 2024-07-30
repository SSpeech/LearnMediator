using MediatR;

namespace LearnMediator.Models
{
    public class UserNotificationHandler : INotificationHandler<UserNotification>
    {
        private readonly FakeStoreData _storeData;
        public async Task Handle(UserNotification notification, CancellationToken cancellationToken)
        {
            await _storeData.EventOccured(notification.User, "new user added");
            await Task.CompletedTask;
        }
    }
}
