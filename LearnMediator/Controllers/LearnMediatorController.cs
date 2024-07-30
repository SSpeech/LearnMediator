using LearnMediator.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnMediator.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class LearnMediatorController(ISender _sender, IPublisher publisher) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            IEnumerable<User> users = await _sender.Send(new UsersQuery());
            return Ok(users);
        }
        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult> GetUserById(int id)
        
        {
            User user = await _sender.Send(new UserQuery(id)); 
            return Ok(user);
        }
        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult> AddUser([FromBody] User user) 
        {
            var userCreated = await _sender.Send(new CreateUserCommand(user));
            return CreatedAtRoute("GetUserById", new {id = user.Id}, userCreated);
        }
    }
}
