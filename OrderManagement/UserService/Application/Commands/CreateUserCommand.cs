using MediatR;

namespace UserService.Application.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; }
        public string Username { get; }
        public string Email { get; }
        public string Password { get; }

        public CreateUserCommand (string name, string username, string email, string password)
        {
            Username = username;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
