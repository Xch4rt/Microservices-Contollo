using MediatR;
using UserService.API.DTOs;

namespace UserService.Application.Commands
{
    public class LoginUserCommand : IRequest<TokenRequestDto>
    {
        public string Username { get; }
        public string Password { get; }

        public LoginUserCommand (string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
