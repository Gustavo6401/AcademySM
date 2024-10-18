using CadastroUsuario.Domain.Models.API;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CadastroUsuario.Infra.Authentication
{
    public class CookieAuthServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieAuthServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LoginAsync(Guid userId, string token, List<GroupsUsers> groupsUsers)
        {
            Claim claim = new Claim(ClaimTypes.NameIdentifier, userId.ToString());
            Claim claim2 = new Claim(ClaimTypes.Name, token);
            List<Claim> claims = [
                claim,
                claim2
            ];

            foreach (var item in groupsUsers)
            {
                Console.WriteLine($"{item.GroupId} {item.Role}");
                Claim claim3 = new Claim($"GroupRole-{item.GroupId}", item.Role!);
                claims.Add(claim3);
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await _httpContextAccessor.HttpContext!.SignInAsync("CookieAuth", claimsPrincipal);
        }

        public async Task LogoutAsync() =>
            await _httpContextAccessor.HttpContext!.SignOutAsync("CookieAuth");
    }
}
