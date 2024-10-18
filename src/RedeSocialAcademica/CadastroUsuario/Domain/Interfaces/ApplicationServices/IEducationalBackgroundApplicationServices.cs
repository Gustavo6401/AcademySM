using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.ApplicationServices
{
    public interface IEducationalBackgroundApplicationServices
    {
        Task<EducationalBackground> Get(Guid id);
        Task<List<EducationalBackground>> GetByUserId(Guid userId);
        Task Create(EducationalBackground background);
        Task Update(EducationalBackground background);
        Task Delete(Guid id);
    }
}
