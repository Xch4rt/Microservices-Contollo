using UserService.Domain.Entities;

namespace UserService.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<User> FindByIdAsync(Guid id);
        Task<User> FindByNameAsync(string name);
        Task<User> FindByEmailAsync(string email);
    }
}
