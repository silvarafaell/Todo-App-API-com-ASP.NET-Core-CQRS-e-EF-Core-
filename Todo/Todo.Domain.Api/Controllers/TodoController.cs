using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandresult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler
        )
        {
            command.User = "franciscorafael";
            return (GenericCommandresult)handler.Handle(command);
        }
    }
}