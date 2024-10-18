using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer.Base;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.ControllerModels;

namespace CadastroUsuario.Domain.Interfaces.Repositories.SqlServer
{
    public interface IUserRepository : ISqlServerRepositoryBase<ApplicationUser>
    {
        Task<LoginInformations> Login(string email, string password);
        Task<ApplicationUser> GetByEmail(string email);
        Task<UserDetailsReturn> UserDetails(Guid id);
    }
}
