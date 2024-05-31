namespace UserService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User() { }

        public User(string name, string username, string email, string password)
        {
            Username = username;
            Name = name;
            Email = email;
            Password = password;
        }


    }
}
