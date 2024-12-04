using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.ApplicationServices
{
    public interface ILinksApplicationServices
    {
        Task Create(Links? links);
        Task Delete(int id);
        Task<Links>? Get(int id);
        Task<List<Links>>? GetByUserId(Guid id);
        Task Update(Links? links);
    }
}
