using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            if (command == null) 
            {
                return BadRequest("Cannot login, not body provided");
            }

            var tokenResponse = await _mediator.Send(command);
            return Ok(tokenResponse);
        }
    }
}
