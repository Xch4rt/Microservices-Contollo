using MediatR;
using UserService.API.DTOs;
using UserService.Application.Queries;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;

namespace UserService.Application.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.FindByIdAsync(request.Id);

                if (user == null)
                {
                    throw new KeyNotFoundException("User not found");
                }

                return new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.Username,
                };
            }
            catch (KeyNotFoundException ex)
            {
                throw new ApplicationException("An error occurred while retrieving the user.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while retrieving the user.", ex);
            }
        }
    }
}
