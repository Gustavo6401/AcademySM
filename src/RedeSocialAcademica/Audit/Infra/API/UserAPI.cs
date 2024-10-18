namespace Audit.Infra.API
{
    public class UserAPI
    {
        private readonly HttpClient _client;
        public UserAPI()
        {
            _client = new HttpClient();
        }

        public async Task Logout()
        {
            await _client.PostAsync("https://localhost:7007/ApplicationUser/Logout/", null);
        }
    }
}
