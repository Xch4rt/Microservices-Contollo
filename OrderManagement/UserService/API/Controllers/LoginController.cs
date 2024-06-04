using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

            try 
            {
                var tokenResponse = await _mediator.Send(command);
                return Ok(tokenResponse);
            } 
            catch (ValidationException ex)
            {
                return BadRequest(new { Message = ex.Message, StackTrace = ex.StackTrace });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while logging in.", ex);
            }
        }
    }
}
