using MediatR;
using UserService.Domain.Entities;

namespace UserService.Application.Queries
{
    public class GetUserByUsernameQuery : IRequest<User>
    {
        public string Username { get; }

        public GetUserByUsernameQuery (string username)
        {
            Username = username;
        }
    }
}
