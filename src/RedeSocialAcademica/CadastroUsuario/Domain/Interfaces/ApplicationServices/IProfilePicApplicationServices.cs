using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Interfaces.ApplicationServices
{
    public interface IProfilePicApplicationServices
    {
        /// <summary>
        /// Creates a Profile Picture.
        /// 
        /// This method doesn't have any validations.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        Task Create(ProfilePic profile);
        /// <summary>
        /// Delete a Profile Picture.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
        /// <summary>
        /// Gets a Profile Picture by his Id an checks wether it is in use or not.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProfilePic> Get(Guid id);
        /// <summary>
        /// Gets all of user's photos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<ProfilePic>> GetByUserId(Guid id);
        Task<ProfilePic> GetById(Guid id);
    }
}
