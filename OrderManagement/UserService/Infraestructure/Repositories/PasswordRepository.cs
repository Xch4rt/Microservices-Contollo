using MediatR;
using Microsoft.AspNetCore.Identity;
using UserService.Domain.Repositories;

namespace UserService.Infraestructure.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string providedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, providedPassword);
        }
    }
}
