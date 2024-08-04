using LearnMediator.Repositories.UserRepository;
using MediatR;

namespace LearnMediator.Abstractions.Notifications
{
    public class UserNotificationHandler : INotificationHandler<UserNotification>
    {
        private readonly FakeStoreData _storeData;

        public UserNotificationHandler(FakeStoreData storeData)
        {
            _storeData = storeData;
        }

        public async Task Handle(UserNotification notification, CancellationToken cancellationToken)
        {
            await _storeData.EventOccured(notification.User, "new user added");
            await Task.CompletedTask;
        }
    }
}
