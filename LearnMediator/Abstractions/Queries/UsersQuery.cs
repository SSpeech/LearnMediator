using LearnMediator.Models;
using MediatR;

namespace LearnMediator.Abstractions.Queries
{
    public class UsersQuery : IQuery<IEnumerable<User>>
    {
    }
}
