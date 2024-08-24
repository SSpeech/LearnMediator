using LearnMediator.Models;

namespace LearnMediator.Repositories.UserRepository;

public class FakeStoreData
{
    private readonly List<User> _users =
    [
        new("Name1", "uniqueemail1@test.com"),
        new("Name2", "uniqueemail2@test.com"),
        new("Name3", "uniqueemail3@test.com"),
    ];

    public async Task<IEnumerable<User>> GetUsersAsync() => await Task.FromResult(_users!);

    /// <summary>
    /// Retrieves the user by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<User?> GetUserById(Guid id)
    {
        var user = _users.SingleOrDefault(x => x.Id == id);
        return await Task.FromResult(user);
    }

    /// <summary>
    /// Retrieves the user by email (unique)
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken = default)
    {
        // Check if the operation has been canceled
        cancellationToken.ThrowIfCancellationRequested();

        var user = _users.SingleOrDefault(x => x.Email == email);
        return await Task.FromResult(user);
    }

    public async Task AddUser(User user)
    {
        //User.Id should be unique and properly added here (EF?) but
        //for the sake of demonstrating it with Guid, we are doing it at User's constructor
        _users.Add(user);
        await Task.CompletedTask;
    }

    public async Task EventOccured(User user, string eventNotification)
    {
        var item = _users.Single(x => x.Id == user.Id);
        item.SetName($"{user.Name} Notification:{eventNotification}");

        await Task.CompletedTask;
    }
}
