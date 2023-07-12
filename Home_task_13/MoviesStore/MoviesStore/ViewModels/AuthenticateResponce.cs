using System.Text.Json.Serialization;

namespace MoviesStore.ViewModels
{
    public class AuthenticateResponce
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("user")]
        public UserViewModel UserViewModel { get; set; }
    }
}
