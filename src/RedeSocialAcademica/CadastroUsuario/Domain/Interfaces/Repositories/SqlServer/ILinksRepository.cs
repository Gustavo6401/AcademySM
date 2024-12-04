using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.Repositories.SqlServer
{
    public interface ILinksRepository
    {
        Task Add(Links? links);
        Task Delete(int id);
        Task<Links>? Get(int id);
        Task<List<Links>>? GetByUserId(Guid id);
        Task Update(Links links);
    }
}
