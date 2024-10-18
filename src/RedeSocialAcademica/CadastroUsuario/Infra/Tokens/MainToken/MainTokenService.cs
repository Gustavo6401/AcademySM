using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.API;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CadastroUsuario.Infra.Tokens.MainToken
{
    public class MainTokenService
    {
        public static string GenerateToken(ApplicationUser user, List<GroupsUsers> groupsUsers)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(MainTokenSettings.Secret);

            List<Claim> claims = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            foreach (var groupUser in groupsUsers)
            {
                var groupRoleClaimValue = JsonSerializer.Serialize(groupUser);
                claims.Add(new Claim("GroupRole", groupRoleClaimValue));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(90),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            string token = tokenHandler.WriteToken(
                           tokenHandler.CreateToken(tokenDescriptor));

            return token;
        }

    }
}
