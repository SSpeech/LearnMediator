using LearnMediator.Models;
using MediatR;

namespace LearnMediator.Abstractions.Queries;

public class UserQuery : IQuery<User>
{
    public UserQuery(int id) => Id = id;

    public int Id { get; set; }
}
