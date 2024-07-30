using MediatR;

namespace LearnMediator.Models
{
    public class UserQuery : IRequest<User>
    {
        public UserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
