using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence;
using CadastroUsuario.Infra.Tokens.MainToken;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CadastroUsuario.Infra.Tokens.IntermediateToken
{
    public class IntermediateTokenService
    {
        public static string GenerateToken(TokenData tokenData)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(IntermediateTokenSettings.Secret);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, tokenData.UsuarioId!),
                new Claim(ClaimTypes.Name, tokenData.Token!)
            });

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(90),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            string token = tokenHandler.WriteToken(
                           tokenHandler.CreateToken(tokenDescriptor));

            return token;
        }
    }
}
