namespace UserService.Infraestructure.Configuration
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int JwtExpireHours { get; set; }
    }
}
