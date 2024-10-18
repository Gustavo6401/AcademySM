using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer.Base;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.Repositories.SqlServer
{
    public interface IEducationalBackgroundRepository : ISqlServerRepositoryBase<EducationalBackground>
    {
        Task<List<EducationalBackground>> GetByUserId(Guid id);
    }
}
