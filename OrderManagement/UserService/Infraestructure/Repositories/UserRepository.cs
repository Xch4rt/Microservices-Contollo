using UserService.Domain.Entities;
using UserService.Domain.Repositories;
using UserService.Infraestructure.Persistence;

namespace UserService.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }


        public async Task AddAsync(User user)
        {
            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _userContext.Users.FindAsync(id);
        }

        public Task<User> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
