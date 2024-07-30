using MediatR;

namespace LearnMediator.Models
{
    public class UsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
