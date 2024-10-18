using CadastroUsuario.Domain.Models.MongoDBCollections.BCryptPersistence;

namespace CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Salts
{
    public interface ISaltsRepository
    {
        Task<SaltsData> GetSaltByEmail(string? email);
        Task Create(SaltsData saltsData);
    }
}
