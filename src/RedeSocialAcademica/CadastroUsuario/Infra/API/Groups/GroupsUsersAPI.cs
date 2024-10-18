using CadastroUsuario.Domain.Models.API;
using Newtonsoft.Json;

namespace CadastroUsuario.Infra.API.Groups
{
    public class GroupsUsersAPI
    {
        private readonly HttpClient _client;
        public GroupsUsersAPI(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<GroupsUsers>> GetAllGroupsUsers(Guid userId)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:7286/api/UserGroup/GetByUserId?userId={userId}");

            string json = await response.Content.ReadAsStringAsync();

            List<GroupsUsers>? list = JsonConvert.DeserializeObject<List<GroupsUsers>>(json);

            return list ?? new List<GroupsUsers>();
        }
    }
}
