namespace UserService.Domain.Repositories
{
    public interface IPasswordRepository
    {
        string HashPassword(string password);

        bool VerifyPassword (string password, string providedPassword);
    }
}
