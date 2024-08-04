using MediatR;

namespace LearnMediator.Models;

public class UserQuery : IQuery<User>
{
    public UserQuery(int id) => Id = id;

    public int Id { get; set; }
}
