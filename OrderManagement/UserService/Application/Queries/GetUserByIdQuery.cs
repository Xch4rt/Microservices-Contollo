using MediatR;
using UserService.Domain.Entities;

namespace UserService.Application.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; }

        public GetUserByIdQuery (Guid id)
        {
            Id = id;
        }
    }
}
