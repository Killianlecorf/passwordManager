//using System.Net.Http.Json;
//using Microsoft.AspNetCore.Components;

//namespace passwordManager.web.Client.Pages
//{
//    public partial class Login
//    {
//        [Inject]
//        private  HttpClient HttpClient { get; set; }

//        [Inject]
//        private required NavigationManager Navigation { get; set; }

//        private LoginModel loginModel = new();
//        private string Message = string.Empty;

//        private async Task HandleLogin()
//        {
//            var response = await HttpClient.PostAsJsonAsync("api/users/login", loginModel);
//            if (response.IsSuccessStatusCode)
//            {
//                Navigation.NavigateTo("/");
//            }
//            else
//            {
//                Message = "Échec de la connexion. Vérifiez vos identifiants.";
//            }
//        }
//    }
//}
