using System.Net.Http.Json;
using passwordManager.web.Client.Models;
using PasswordManager.Web.Client.Models;

namespace PasswordManager.Web.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginAsync(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/login", loginModel);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterModel registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users", registerModel);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }

        public async Task LogoutAsync()
        {
            await _httpClient.PostAsync("api/users/logout", null);
        }

        public async Task<bool> Login(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/login", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<string?> GetToken()
        {
            return null;
        }

        public async Task Logout()
        {
            await LogoutAsync();
        }
    }
}