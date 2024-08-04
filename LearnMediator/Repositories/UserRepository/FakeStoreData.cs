using LearnMediator.Models;

namespace LearnMediator.Repositories.UserRepository;

public class FakeStoreData
{
    private readonly List<User>? _users =
    [
        new() { Id = 1, Name = "Test", Email = "test.com" },
        new() { Id = 2, Name = "Test", Email = "test.com" },
        new() { Id = 3, Name = "Test", Email = "test.com" }
    ];

    public async Task AddUser(User user)
    {
        _users!.Add(user);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await Task.FromResult(_users!);
    }
    public async Task<User> GetUserById(int id)
    {
        User? user = _users!.SingleOrDefault(x => x.Id == id);
        return await Task.FromResult(user!);
    }
    public async Task EventOccured(User user, string eventNotification)
    {
        _users!.Single(x => x.Id == user.Id).Name = $"{user.Name} Notification:{eventNotification}";
        await Task.CompletedTask;
    }
}
