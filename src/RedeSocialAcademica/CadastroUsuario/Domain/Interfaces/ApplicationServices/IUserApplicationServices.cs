using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.API;
using CadastroUsuario.Domain.Models.ControllerModels;

namespace CadastroUsuario.Domain.Interfaces.ApplicationServices
{
    public interface IUserApplicationServices
    {
        /// <summary>
        /// This method is going to validate user's data and calls the methods UserRepository.GetByEmail
        /// and UserRepository.Create.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<UserCreateReturn> CreateAsync(ApplicationUser user);
        /// <summary>
        /// This method is responsible for user's deletions.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
        /// <summary>
        /// This method is responsible for user's login, and it is necessary to block the user whenever it
        /// forgets its password more than 10 times.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<LoginReturn> Login(Login login);
        /// <summary>
        /// This method is responsible for user's updates.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task Update(ApplicationUser user);
        /// <summary>
        /// Gets users by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationUser> GetById(Guid id);
        /// <summary>
        /// Method Responsible for making Logout.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<string> Logout();

        Task<ApplicationUser> GetByEmail(string email);
        Task ModifyAuthCookie(Guid id);
        Task<UserDetailsReturn> UserDetails(Guid id);
        Task<UserPortfolio> Portfolio(Guid id);
    }
}
