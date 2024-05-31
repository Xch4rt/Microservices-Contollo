using MediatR;
using UserService.API.DTOs;
using UserService.Application.Commands;
using UserService.Domain.Repositories;

namespace UserService.Application.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenRequestDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRepository _passwordRepository;
        private readonly ITokenRepository _tokenRepository;

        public LoginUserCommandHandler (IUserRepository userRepository, IPasswordRepository passwordRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _passwordRepository = passwordRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<TokenRequestDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByUsernameAsync(request.Username);
            if (user == null || !_passwordRepository.VerifyPassword(request.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var token = _tokenRepository.GenerateToken(user);
            return new TokenRequestDto { Token = token };
        }
    }
}
