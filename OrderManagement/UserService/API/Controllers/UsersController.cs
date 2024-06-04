using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using UserService.Application.Commands;
using UserService.Application.Queries;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            if (command == null)
            {
                return BadRequest("Cannot created, not body provided");
            }

            try
            {
                var userId = await _mediator.Send(command);
                return Ok(userId);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Message = ex.Message, StackTrace = ex.StackTrace });
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating the user.", ex);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserById (Guid id)
        {
            try
            {
                var query = new GetUserByIdQuery(id);
                var user = await _mediator.Send(query);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the user.", ex);
            }
        }
    }
}
