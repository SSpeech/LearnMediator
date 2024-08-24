using LearnMediator.Abstractions.Queries;

namespace LearnMediator.Features.User.Queries;

public class GetUsersListQuery : IQuery<IEnumerable<Models.User>>
{
}