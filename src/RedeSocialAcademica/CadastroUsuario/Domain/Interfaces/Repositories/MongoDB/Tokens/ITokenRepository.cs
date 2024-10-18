using CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence;

namespace CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Tokens
{
    public interface ITokenRepository
    {
        Task Create(TokenData token);
        Task<TokenData> GetTokenByUserId(string userId);
        Task<TokenData> GetByToken(string token);
        Task Remove(string id);
    }
}
