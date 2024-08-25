using LearnMediator.Abstractions.Queries;

namespace LearnMediator.Features.User.Queries;

public class GetUserByIdQuery : IQuery<Models.User>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
