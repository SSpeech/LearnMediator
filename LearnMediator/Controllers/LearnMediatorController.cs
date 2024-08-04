using LearnMediator.Abstractions;
using LearnMediator.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LearnMediator.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class LearnMediatorController(ISender _sender, IPublisher _publisher) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetUsers(CancellationToken cancellationToken)
        {
            Result<IEnumerable<User>> users = await _sender.Send(new UsersQuery(),cancellationToken);

            return users.IsSuccess ? Ok(users.Value) : NotFound(users.Error);
        }

        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult> GetUserById(int id, CancellationToken cancellationToken)
        
        {
            Result<User> user = await _sender.Send(new UserQuery(id),cancellationToken); 

            return user.IsSuccess ? Ok(user.Value) : NotFound(user.Error);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult> AddUser([FromBody] User user, CancellationToken cancellationToken) 
        {
            var userCreated = await _sender.Send(new CreateUserCommand(user),cancellationToken);
            return userCreated.IsSuccess? CreatedAtRoute("GetUserById",new { id = userCreated.Value.Id}, userCreated.Value) : BadRequest(userCreated.Error);
        }
    }
}
