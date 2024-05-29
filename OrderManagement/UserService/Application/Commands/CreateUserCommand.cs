using MediatR;

namespace UserService.Application.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }

        public CreateUserCommand (string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
