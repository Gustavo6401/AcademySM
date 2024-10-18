using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer.Base;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.Repositories.SqlServer
{
    public interface IUserLockoutRepository : ISqlServerRepositoryBase<UserLockout>
    {
        /// <summary>
        /// Gets user's last lockout.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserLockout> GetLastUserLockoutByUserId(Guid userId);
    }
}
