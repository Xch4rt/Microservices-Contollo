using MediatR;
using UserService.API.DTOs;
using UserService.Domain.Entities;

namespace UserService.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; }

        public GetUserByIdQuery (Guid id)
        {
            Id = id;
        }
    }
}
