namespace PasswordManager.api.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public List<Password>? Passwords { get; set; }
    }
}

namespace PasswordManager.api.Models
{
    public class LoginModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}

namespace PasswordManager.api.Models
{
    public class RegisterModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}