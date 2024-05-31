using UserService.Domain.Entities;

namespace UserService.Domain.Repositories
{
    public interface ITokenRepository
    {
        string GenerateToken(User user);
    }
}
