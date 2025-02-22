namespace passwordManager.web.Client.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

// filepath: /c:/Users/Killian/source/repos/Killianlecorf/passwordManager/src/passwordManager.web/passwordManager.web.Client/Models/RegisterModel.cs
namespace passwordManager.web.Client.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

// filepath: /c:/Users/Killian/source/repos/Killianlecorf/passwordManager/src/passwordManager.web/passwordManager.web.Client/Models/LoginResponse.cs
namespace passwordManager.web.Client.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
    }
}


// filepath: /c:/Users/Killian/source/repos/Killianlecorf/passwordManager/src/passwordManager.web/passwordManager.web.Client/Models/RegisterResponse.cs
namespace passwordManager.web.Client.Models
{
    public class RegisterResponse
    {
        public string Message { get; set; }
    }
}