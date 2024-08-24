using LearnMediator.DTOs;
using LearnMediator.Extensions;
using LearnMediator.Features.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearnMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ISender sender) : ControllerBase
    {
        [HttpGet(Name = "GetUsersList")]
        public async Task<ActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var result = await sender.Send(new GetUsersListQuery(), cancellationToken);
            return result.IsSuccess
                ? Ok(result.Value)
                : NotFound(result.Error);
        }

        [HttpGet("{id:guid}", Name = "GetUserById")]
        public async Task<ActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var result = await sender.Send(new GetUserByIdQuery(id), cancellationToken);
            return result.IsSuccess
                ? Ok(result.Value)
                : NotFound(result.Error);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await sender.Send(dto.Map(), cancellationToken);
            return result.IsSuccess
                ? CreatedAtRoute("GetUserById", new { id = result.Value }, result.Value)
                : result.HandleFailure();
        }
    }
}
