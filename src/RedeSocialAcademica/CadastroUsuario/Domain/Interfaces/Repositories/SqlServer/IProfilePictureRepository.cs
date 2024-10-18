using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer.Base;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.Repositories.SqlServer
{
    public interface IProfilePictureRepository : ISqlServerRepositoryBase<ProfilePic>
    {
        /// <summary>
        /// Gets a list of all user's profile pics.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<ProfilePic>> GetByUserId(Guid id);
        /// <summary>
        /// Gets an Profile Picture that is now in use.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        Task<ProfilePic> GetValidProfilePic(Guid userId);
    }
}
