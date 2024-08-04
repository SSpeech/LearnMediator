using MediatR;

namespace LearnMediator.Models
{
    public class UsersQuery : IQuery<IEnumerable<User>>
    {
    }
}
