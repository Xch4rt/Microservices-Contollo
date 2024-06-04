using BCrypt.Net;
using MediatR;
using System.ComponentModel.DataAnnotations;
using UserService.Application.Commands;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;

namespace UserService.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRepository _passwordRepository;

        public CreateUserCommandHandler (IUserRepository userRepository, IPasswordRepository passwordRepository)
        {
            _userRepository = userRepository;
            _passwordRepository = passwordRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var hashedPassword = _passwordRepository.HashPassword(request.Password);
                var user = new User(
                    request.Name,
                    request.Username,
                    request.Email,
                    hashedPassword
                );

                await _userRepository.AddAsync(user);

                return user.Id;
            }
            catch (ValidationException ex)
            {
                throw new ApplicationException("Validation error occurred while creating the user.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while creating the user.", ex);
            }
        }
    }
}
